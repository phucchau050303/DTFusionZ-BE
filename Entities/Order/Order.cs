namespace DTFusionZ_BE.Entitites
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public string CustomerPhone { get; set; } = string.Empty;

        public string CustomerEmail { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string OrderType { get; set; } = string.Empty; //"Dine-In" or "Takeaway"  

        public decimal OrderTotal { get; set; }
        public string Status { get; set; } = "New"; // e.g., "New," "In Progress," "Ready," "Completed," "Canceled"
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}