using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moontest1.Data;
using moontest1.Models;

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

        [HttpPost("PostUser")]
        public void PostUser(User user)
        {
            AppDbContext context = new AppDbContext();

            context.User.Add(user);
            context.SaveChanges();
        }

        [HttpPut("PutUser")]
        public void PutUser(User user)
        {
            
            
            User userToChange = _context.User.FirstOrDefault(x => user.UserId == user.UserId);
            userToChange.Username = user.Username;
            _context.SaveChanges();
            
        }

        [HttpDelete("DeleteUser/{id}")]
        public void DeleteUser(long id)
        {
        
           _context.User.Where(x => x.UserId == id).ExecuteDelete();
            _context.SaveChanges();
        }
    }
}
