using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTFusionZ_BE.Data;
using DTFusionZ_BE.Entities;
using DTFusionZ_BE.Models.DTOs;

namespace DTFusionZ_BE.Controllers
{
    [Route("api/options/option-groups")]
    [ApiController]

    public class OptionGroupController : ControllerBase
    {
        private readonly DTFusionZDbContext _context;

        public OptionGroupController(DTFusionZDbContext context)
        {
            _context = context;
        }

        // GET: api/options/option-groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionGroup>>> GetOptionGroups()
        {
            return await _context.OptionGroups
                .Include(og => og.OptionValues)
                .Include(og => og.ItemOptionGroups)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OptionGroup>> GetOptionGroup(int id)
        {
            var optionGroup = await _context.OptionGroups
                .Include(og => og.OptionValues)
                .Include(og => og.ItemOptionGroups)
                .FirstOrDefaultAsync(og => og.Id == id);

            if (optionGroup == null)
            {
                return NotFound();
            }

            return optionGroup;
        }

        // POST: api/options/option-groups
        [HttpPost]
        public async Task<ActionResult<OptionGroup>> CreateOptionGroup(OptionGroupCreateDto optionGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var optionGroup = new OptionGroup
            {
                Name = optionGroupDto.Name,
                IsRequired = optionGroupDto.IsRequired,
                MaxSelections = optionGroupDto.MaxSelections,
            };

            _context.OptionGroups.Add(optionGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOptionGroup), new { id = optionGroup.Id }, optionGroup);
        }


        // PUT: api/options/option-groups/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOptionGroup(int id, OptionGroupCreateDto optionGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var optionGroup = await _context.OptionGroups.FindAsync(id);
            if (optionGroup == null)
            {
                return NotFound();
            }

            optionGroup.Name = optionGroupDto.Name;
            optionGroup.IsRequired = optionGroupDto.IsRequired;
            optionGroup.MaxSelections = optionGroupDto.MaxSelections;
            optionGroup.UpdatedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/options/option-groups/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOptionGroup(int id)
        {
            var optionGroup = await _context.OptionGroups.FindAsync(id);
            if (optionGroup == null)
            {
                return NotFound();
            }

            optionGroup.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OptionGroupExists(int id)
        {
            return _context.OptionGroups.Any(e => e.Id == id);
        }
        

    }
}