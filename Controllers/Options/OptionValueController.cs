using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTFusionZ_BE.Data;
using DTFusionZ_BE.Entities;
using DTFusionZ_BE.Models.DTOs;

namespace DTFusionZ_BE.Controllers.Options
{
    [Route("api/options/option-values")]
    [ApiController]
    public class OptionValueController : ControllerBase
    {
        private readonly DTFusionZDbContext _context;

        public OptionValueController(DTFusionZDbContext context)
        {
            _context = context;
        }

        // GET: api/options/option-values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionValue>>> GetOptionValues()
        {
            return await _context.OptionValues
                .Include(ov => ov.OptionGroup)
                .ToListAsync();
        }

        // GET: api/options/option-values/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OptionValue>> GetOptionValue(int id)
        {
            var optionValue = await _context.OptionValues
                .Include(ov => ov.OptionGroup)
                .FirstOrDefaultAsync(ov => ov.Id == id);

            if (optionValue == null)
            {
                return NotFound();
            }

            return optionValue;
        }

        // POST: api/options/option-values
        [HttpPost]
        public async Task<ActionResult<OptionValue>> CreateOptionValue(OptionValueDto optionValueDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var optionValue = new OptionValue
            {
                Name = optionValueDto.Name,
                PriceModifier = optionValueDto.PriceModifier,
                OptionGroupId = optionValueDto.OptionGroupId
            };

            _context.OptionValues.Add(optionValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOptionValue), new { id = optionValue.Id }, optionValue);
        }

        //DELETE: api/options/option-values/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOptionValue(int id)
        {
            var optionValue = await _context.OptionValues.FindAsync(id);
            if (optionValue == null)
            {
                return NotFound();
            }

            _context.OptionValues.Remove(optionValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}