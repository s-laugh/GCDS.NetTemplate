namespace GC.WebTemplate.GCDS.Models
{
    public class GCDSFooterModel
    {
        public enum DisplayType
        {
            compact,
            full
        }

        public string? ContextualHeading { get; set; }
        public string? ContextualLinks { get; set; }
        public DisplayType Display { get; set; } = DisplayType.compact;
        public string? SubLinks { get; set; }
    }
}
