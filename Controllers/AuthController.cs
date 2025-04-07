using Microsoft.AspNetCore.Mvc;
using moontest1.Data;
using moontest1.Services;
using moontest1.DTO;

namespace moontest1.Models
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;
        private readonly PasswordHasher _hasher;

        public AuthController(AppDbContext context, TokenService tokenService, PasswordHasher hasher)
        {
            _context = context;
            _tokenService = tokenService;
            _hasher = hasher;
        }

        // POST: auth/register
        // Registers a new user
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO model)
        {
            // Check if the username already exists in the DB
            if (_context.User.Any(u => u.Username == model.Username))
                return BadRequest("Username already exists");

            var role = _context.Role.FirstOrDefault(r => r.RoleName == model.Role);
            if (role == null)
                return BadRequest("Invalid role");

            // Create a new user object with the given info
            // realistically, you don't want to give users the option to create their own role
            // but it will work for now
            var user = new User
            {
                Username = model.Username,
                // Hash the password before storing — NEVER store raw passwords
                PasswordHash = _hasher.HashPassword(null, model.Password),
                RoleId = role.RoleId,
                UserEntraId = null, // Optional external auth ID, left null for now
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Save the new user to the database
            _context.User.Add(user);
            _context.SaveChanges();

            // Create a JWT token for the new user
            var token = _tokenService.CreateToken(user.Username, role.RoleName);

            // Return the token and basic user info
            // returning the token ONLY for testing purposes. you never want to give open access to this
            return Ok(new
            {
                token = token,
                username = user.Username,
                role = role.RoleName
            });
        }

        // POST: auth/login
        // Logs in an existing user and returns a JWT
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            // Try to find the user and get their role name in the same query
            var user = _context.User
                .Where(u => u.Username == model.Username)
                .Select(u => new { u, u.Role.RoleName })
                .FirstOrDefault();

            // If user not found or password is wrong, return unauthorized
            if (user == null || !_hasher.VerifyPassword(user.u, model.Password))
                return Unauthorized("Invalid username or password");

            // Create JWT if login is valid
            var token = _tokenService.CreateToken(user.u.Username, user.RoleName);

            // Return token and basic user info
            // again, ONLY for testing purposes. NEVER give open access to a user's jwt
            return Ok(new
            {
                token = token,
                username = user.u.Username,
                role = user.RoleName
            });
        }
    }
}