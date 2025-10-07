namespace DTFusionZ_BE.Entitites
{
    public class OptionGroup
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public bool IsRequired { get; set; }
    }
}