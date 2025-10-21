namespace DTFusionZ_BE.Entities
{
    public class OrderItemOption
    {
        public int Id { get; set; }

        public decimal PriceModifier { get; set; }

        // Foreign key to OrderItem
        public int OrderItemId { get; set; }
        public OrderItem? OrderItem { get; set; }

        // Foreign key to OptionValue
        public int OptionValueId { get; set; }
        public OptionValue? OptionValue { get; set; }

    }
}