using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moontest1.Data;

namespace moontest1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.User.ToListAsync();
            return Ok(users);
        }
    }
}
