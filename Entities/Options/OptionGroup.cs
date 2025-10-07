namespace DTFusionZ_BE.Entities
{
    public class OptionGroup
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
        public ICollection<OptionValue> OptionValues { get; set; } = new List<OptionValue>();
    }
}