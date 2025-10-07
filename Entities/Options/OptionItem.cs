namespace DTFusionZ_BE.Entitites
{
    public class OptionItem
    {
        public int MaxSelections { get; set; }

        //FK

        public int OptionGroupId { get; set; }
        public OptionGroup OptionGroup { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}