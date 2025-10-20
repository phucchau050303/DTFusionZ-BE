namespace DTFusionZ_BE.Entities
{
    public class ItemOptionGroup
    {
        public int ItemId { get; set; }
        public Item? Item { get; set; }

        public int OptionGroupId { get; set; }
        public OptionGroup? OptionGroup { get; set; }

        // Additional properties if needed
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}