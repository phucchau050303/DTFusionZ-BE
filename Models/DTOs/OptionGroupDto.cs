using System.ComponentModel.DataAnnotations;

namespace DTFusionZ_BE.Models.DTOs
{
    public class OptionGroupCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsRequired { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "MaxSelections must be at least 1.")]
        public int MaxSelections { get; set; }

        public List<OptionValueDto> OptionValues { get; set; } = new List<OptionValueDto>();

        public List<ItemOptionGroupCreateDto> ItemOptionGroups { get; set; } = new List<ItemOptionGroupCreateDto>();
    }

    public class OptionGroupResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
        public int MaxSelections { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<OptionValueDto> OptionValues { get; set; } = new();
        public List<ItemOptionGroupResponseDto> Items { get; set; } = new();
    }

}