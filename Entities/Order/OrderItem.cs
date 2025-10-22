namespace DTFusionZ_BE.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public string SpecialInstructions { get; set; } = string.Empty;

        public ICollection<OrderItemOption> OrderItemOptions { get; set; } = new List<OrderItemOption>();
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Foreign key
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

    }
}