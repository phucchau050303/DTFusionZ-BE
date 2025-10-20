namespace DTFusionZ_BE.Entities
{
    public class OptionGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
        public int MaxSelections { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation property for option values only
        public ICollection<OptionValue> OptionValues { get; set; } = new List<OptionValue>();
        
        // Navigation property for the junction table
        public ICollection<ItemOptionGroup> ItemOptionGroups { get; set; } = new List<ItemOptionGroup>();
    }
}