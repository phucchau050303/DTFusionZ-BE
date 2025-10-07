namespace DTFusionZ_BE.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public string CustomerPhone { get; set; } = string.Empty;

        public string CustomerEmail { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public string OrderType { get; set; } = string.Empty; //"Dine-In" or "Takeaway"  

        public decimal OrderTotal { get; set; }
        public string Status { get; set; } = "New"; // e.g., "New," "In Progress," "Ready," "Completed," "Canceled"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}