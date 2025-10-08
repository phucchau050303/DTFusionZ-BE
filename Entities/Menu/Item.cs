namespace DTFusionZ_BE.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty; 

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Foreign key to Category
        public int CategoryId { get; set; }
    public Category? Category { get; set; }
    }
    
}