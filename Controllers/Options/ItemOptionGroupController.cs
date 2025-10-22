using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTFusionZ_BE.Data;
using DTFusionZ_BE.Entities;
using DTFusionZ_BE.Models.DTOs;

namespace DTFusionZ_BE.Controllers
{
    [Route("api/options/item-option-groups")]
    [ApiController]
    public class ItemOptionGroupController : ControllerBase
    {
        private readonly DTFusionZDbContext _context;

        public ItemOptionGroupController(DTFusionZDbContext context)
        {
            _context = context;
        }

        // GET: api/options/item-option-groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemOptionGroupResponseDto>>> GetItemOptionGroups()
        {
            var itemOptionGroups = await _context.Set<ItemOptionGroup>()
                .Include(iog => iog.Item)
                    .ThenInclude(i => i.Category)
                .Include(iog => iog.OptionGroup)
                    .ThenInclude(og => og.OptionValues)
                .Where(iog => iog.DeletedAt == null)
                .Select(iog => new ItemOptionGroupResponseDto
                {
                    ItemId = iog.Item!.Id,
                    ItemName = iog.Item.Name,
                    CategoryName = iog.Item.Category!.Name,
                    OptionGroupId = iog.OptionGroup!.Id,
                    OptionGroupName = iog.OptionGroup.Name,
                    IsRequired = iog.OptionGroup.IsRequired,
                    MinSelection = iog.OptionGroup.IsRequired ? 1 : 0,
                    MaxSelection = iog.OptionGroup.MaxSelections,
                    OptionValues = iog.OptionGroup.OptionValues
                        .Where(ov => ov.DeletedAt == null)
                        .Select(ov => new OptionValueResponseDto
                        {
                            Id = ov.Id,
                            Name = ov.Name,
                            PriceModifier = ov.PriceModifier
                        }).ToList()
                })
                .ToListAsync();

            return Ok(itemOptionGroups);
        }

        // POST: api/options/item-option-groups
        [HttpPost]
        public async Task<ActionResult<ItemOptionGroup>> CreateItemOptionGroup(ItemOptionGroupCreateDto itemOptionGroupCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemOptionGroup = new ItemOptionGroup
            {
                ItemId = itemOptionGroupCreateDto.ItemId,
                OptionGroupId = itemOptionGroupCreateDto.OptionGroupId,
            };

            _context.Set<ItemOptionGroup>().Add(itemOptionGroup);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItemOptionGroups), new { id = itemOptionGroup.ItemId }, itemOptionGroup);
        }

        //PUT: api/options/item-option-groups/{itemId}/{optionGroupId}
        [HttpPut("{itemId}/{optionGroupId}")]
        public async Task<IActionResult> UpdateItemOptionGroup(int itemId, int optionGroupId, ItemOptionGroupCreateDto itemOptionGroupCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemOptionGroup = await _context.Set<ItemOptionGroup>()
                .FirstOrDefaultAsync(iog => iog.ItemId == itemId && iog.OptionGroupId == optionGroupId);
            if (itemOptionGroup == null)
            {
                return NotFound();
            }

            itemOptionGroup.ItemId = itemOptionGroupCreateDto.ItemId;
            itemOptionGroup.OptionGroupId = itemOptionGroupCreateDto.OptionGroupId;

            try 
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();


        }

        // DELETE: api/options/item-option-groups/{itemId}/{optionGroupId}
        [HttpDelete("{itemId}/{optionGroupId}")]
        public async Task<IActionResult> DeleteItemOptionGroup(int itemId, int optionGroupId)
        {
            var itemOptionGroup = await _context.Set<ItemOptionGroup>()
                .FirstOrDefaultAsync(iog => iog.ItemId == itemId && iog.OptionGroupId == optionGroupId);

            if (itemOptionGroup == null)
            {
                return NotFound();
            }

            itemOptionGroup.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}