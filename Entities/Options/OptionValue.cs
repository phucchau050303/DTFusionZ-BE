namespace DTFusionZ_BE.Entitites
{ 
    public class OptionValue
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal PriceModifier { get; set; }

        // Foreign key to OptionGroup
        public int OptionGroupId { get; set; }
        
        public OptionGroup OptionGroup { get; set; }
    } 
}