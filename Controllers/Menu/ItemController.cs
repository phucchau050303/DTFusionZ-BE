using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTFusionZ_BE.Data;
using DTFusionZ_BE.Entities;
using DTFusionZ_BE.Models.DTOs;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Components.Forms;

namespace DTFusionZ_BE.Controllers
{
    [Route("api/menu/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly DTFusionZDbContext _context;

        public ItemController(DTFusionZDbContext context)
        {
            _context = context;
        }

        // GET: api/meni/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemReturnDto>>> GetItems()
        {
            return await _context.Items
                .Where(i => i.DeletedAt == null)
                .Include(i => i.Category)
                .Select(i => new ItemReturnDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    ShortDescription = i.ShortDescription,
                    Price = i.Price,
                    ImageUrl = i.ImageUrl,
                    IsAvailable = i.IsAvailable,
                    CreatedAt = i.CreatedAt,
                    UpdatedAt = i.UpdatedAt,
                    CategoryId = i.CategoryId,
                    CategoryName = i.Category != null ? i.Category.Name : string.Empty
                })
                .ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemReturnDto>> GetItem(int id)
        {
            var item = await _context.Items
                .Where(i => i.DeletedAt == null && i.Id == id)
                .Include(i => i.Category)
                .Select(i => new ItemReturnDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    ShortDescription = i.ShortDescription,
                    Price = i.Price,
                    ImageUrl = i.ImageUrl,
                    IsAvailable = i.IsAvailable,
                    CreatedAt = i.CreatedAt,
                    UpdatedAt = i.UpdatedAt,
                    CategoryId = i.CategoryId,
                    CategoryName = i.Category != null ? i.Category.Name : string.Empty
                })
                .FirstOrDefaultAsync();
            try
            {
                if (item == null)
                {
                    return NotFound();
                }

                return item;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(ItemCreateDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Categories.FindAsync(itemDto.CategoryId);

            if (category == null)
            {
                return BadRequest($"Category with ID {itemDto.CategoryId} does not exist.");
            }

            var item = new Item
            {
                Name = itemDto.Name,
                Description = itemDto.Description,
                ShortDescription = itemDto.ShortDescription,
                Price = itemDto.Price,
                ImageUrl = itemDto.ImageUrl,
                IsAvailable = itemDto.IsAvailable,
                CategoryId = itemDto.CategoryId
            };

            try
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, ItemCreateDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(itemDto.CategoryId);

            if (category == null)
            {
                return BadRequest($"Category with ID {itemDto.CategoryId} does not exist.");
            }

            item.Name = itemDto.Name;
            item.Description = itemDto.Description;
            item.ShortDescription = itemDto.ShortDescription;
            item.Price = itemDto.Price;
            item.ImageUrl = itemDto.ImageUrl;
            item.IsAvailable = itemDto.IsAvailable;
            item.CategoryId = itemDto.CategoryId;
            item.UpdatedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            item.DeletedAt = DateTime.UtcNow;
            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}