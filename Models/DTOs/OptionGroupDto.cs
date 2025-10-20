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
    }

    public class ItemOptionGroupResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
        public int MaxSelections { get; set; }
        public List<OptionValueDto> OptionValues { get; set; } = new List<OptionValueDto>();
    }
}