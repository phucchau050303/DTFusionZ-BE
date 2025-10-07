namespace DTFusionZ_BE.Entitites
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty; 

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Foreign key to Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
    
}