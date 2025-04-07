using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace moontest1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class testController : ControllerBase
    {
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly() // only allows admin roles
        { 
            return Ok("Welcome, Admin!");
        }
        [HttpGet("User")]
        [Authorize(Roles = "User")]
        public IActionResult UserAccess() // only allows user roles
        {
            return Ok("Welcome, User");
        }

        [HttpGet("Public")]
        [AllowAnonymous]
        public IActionResult PublicAccess() // allows anybody
        {
            return Ok("No token needed here.");
        }
    }
}
