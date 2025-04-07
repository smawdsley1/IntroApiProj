using IntroAPIProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moontest1.Data;
using moontest1.Models;

namespace IntroAPIProject.Controllers
{
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ItemController(AppDbContext db)
        {
            _db = db;
        }
        [Authorize(Roles = "User, Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> getItems() 
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

        [Authorize(Roles = "Admin, User")]
        [HttpPost("[action]")]
        public async Task<IActionResult> postItem([FromBody] Item model)
        {
            try
            {
                var NewItem = new Item{
                    UserId = model.UserId,
                    CategoryId = model.CategoryId,
                    ItemName = model.ItemName,
                    Description = model.Description,
                    Price = model.Price,
                    IsActive = model.IsActive,
                };
                _db.Item.Add(NewItem);
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message + "\nStack Trace: " + e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        // we want to only authorize users that have created this item to update said item 
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

        // we only want to authorize admins and the user who posted the item to be able to delete something
        [Authorize(Roles = "Admin")]
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
