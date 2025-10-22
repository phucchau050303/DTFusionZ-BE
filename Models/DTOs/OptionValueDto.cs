using System.ComponentModel.DataAnnotations;

namespace DTFusionZ_BE.Models.DTOs
{
    public class OptionValueDto
    {
        public int Id { get; set; }
        public int OptionGroupId { get; set; }
        public required string Name { get; set; }
        public decimal PriceModifier { get; set; }
    }

    public class OptionValueResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceModifier { get; set; }
        public int OptionGroupId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}