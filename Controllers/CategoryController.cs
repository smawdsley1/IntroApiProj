using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moontest1.Data;

namespace moontest1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            var categories = await _context.Category.ToListAsync();
            return Ok(categories);
        }
    }
}
