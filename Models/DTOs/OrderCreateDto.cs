namespace DTFusionZ_BE.Models.DTOs
{
    public class OrderCreateDto
    {
        public required string CustomerName { get; set; }
        public required string CustomerPhone { get; set; }
        public required string CustomerEmail { get; set; }
        public required string OrderType { get; set; }
        public List<OrderItemCreateDto> Items { get; set; } = new();
    }

    public class OrderItemCreateDto
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string SpecialInstructions { get; set; } = string.Empty;
        public List<OrderItemOptionCreateDto> Options { get; set; } = new();
    }

    public class OrderItemOptionCreateDto
    {
        public int OptionValueId { get; set; }
    }

    public class OrderStatusUpdateDto
    {
        public required string Status { get; set; }
    }
}