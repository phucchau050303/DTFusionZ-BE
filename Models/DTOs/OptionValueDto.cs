using System.ComponentModel.DataAnnotations;

namespace DTFusionZ_BE.Models.DTOs
{
    public class OptionValueDto
    {
        [Required]
        public string Name { get; set; }

        public decimal PriceModifier { get; set; }

        [Required]
        public int OptionGroupId { get; set; }
    }
}