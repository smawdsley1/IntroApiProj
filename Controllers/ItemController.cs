using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moontest1.Data;

namespace moontest1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            var items = await _context.Item.ToListAsync();
            return Ok(items);
        }
    }
}
