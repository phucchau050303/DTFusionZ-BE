namespace DTFusionZ_BE.Entities
{
    public class OptionValue
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal PriceModifier { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Foreign key
        public int OptionGroupId { get; set; }
        public OptionGroup? OptionGroup { get; set; }
    }
}