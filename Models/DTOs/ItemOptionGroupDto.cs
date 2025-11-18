using System.ComponentModel.DataAnnotations;

namespace DTFusionZ_BE.Models.DTOs
{
    public class ItemOptionGroupResponseDto
    {
        public int ItemId { get; set; }
        public required string ItemName { get; set; }
        public int OptionGroupId { get; set; }
        public required string OptionGroupName { get; set; }
        public bool IsRequired { get; set; }
        public int MinSelection { get; set; }
        public int MaxSelection { get; set; }
        public required List<OptionValueResponseDto> OptionValues { get; set; }
    }

    public class ItemOptionGroupCreateDto
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int OptionGroupId { get; set; }
        public int MinSelection { get; set; }
        public int MaxSelection { get; set; }
    }
    
}