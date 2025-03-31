using IntroAPIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moontest1.Data;

namespace IntroAPIProject.Controllers
{
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ItemController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> getItems() // gets all items
        {
            try
            {
                var items = await _db.Item.ToListAsync();
                return Ok(items);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message + "\nStack Trace: " + e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> postItem([FromBody] Item newItem)
        {
            try
            {
                await _db.Item.AddAsync(newItem);
                await _db.SaveChangesAsync();
                return Ok(newItem);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message + "\nStack Trace: " + e.StackTrace);
                return BadRequest(e.Message);
            }
        }
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> updateItem(Int64 id, [FromBody] Item updatedItem)
        {
            try
            {
                var item = await _db.Item.FirstOrDefaultAsync(i => i.ItemId == id);
                if (item == null)
                {
                    return NotFound($"Item with ID {id} not found.");
                }

                // Update properties
                item.UserId = updatedItem.UserId;
                item.CategoryId = updatedItem.CategoryId;
                item.ItemName = updatedItem.ItemName;
                item.Description = updatedItem.Description;
                item.Price = updatedItem.Price;
                item.IsActive = updatedItem.IsActive;

                await _db.SaveChangesAsync();
                return Ok(item);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message + "\nStack Trace: " + e.StackTrace);
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> deleteItem(Int64 id)
        {
            try
            {
                var item = await _db.Item.FirstOrDefaultAsync(i => i.ItemId == id);
                if (item == null)
                {
                    return NotFound($"Item with ID {id} not found.");
                }

                _db.Item.Remove(item);
                await _db.SaveChangesAsync();
                return Ok($"Item with ID {id} deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message + "\nStack Trace: " + e.StackTrace);
                return BadRequest(e.Message);
            }
        }

    }
}
