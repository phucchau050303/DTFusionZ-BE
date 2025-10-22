using System.ComponentModel.DataAnnotations;

namespace DTFusionZ_BE.Models.DTOs
{
    public class ItemOptionGroupResponseDto
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public int OptionGroupId { get; set; }
        public string OptionGroupName { get; set; }
        public bool IsRequired { get; set; }
        public int MinSelection { get; set; }
        public int MaxSelection { get; set; }
        public List<OptionValueDto> OptionValues { get; set; }
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