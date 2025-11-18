using DTFusionZ_BE.Entities;

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

    public class OrderItemReturnDto
    {
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string SpecialInstructions { get; set; } = string.Empty;
        public List<OrderItemOptionReturnDto> Options { get; set; } = new();
    }

    public class OrderItemOptionReturnDto
    {
        public string OptionValueName { get; set; } = string.Empty;
    }

    public class OrderStatusUpdateDto
    {
        public required string Status { get; set; }
    }

    public class OrderReturnDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string OrderType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemReturnDto> Items { get; set; } = new(); 
        
    }
}