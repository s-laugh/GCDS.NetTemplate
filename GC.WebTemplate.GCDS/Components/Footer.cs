namespace GC.WebTemplate.GCDS.Components
{
    public class Footer : Common
    {
        public enum DisplayType
        {
            compact,
            full
        }

        /// <summary>
        /// A heading for a custom section of footer links
        /// </summary>
        public string? ContextualHeading { get; set; }

        /// <summary>
        /// Add up to 3 custom footer links
        /// </summary>
        public List<Link>? ContextualLinks { get; set; }

        /// <summary>
        /// include the GC footer with type 'full'
        /// type 'compact' and not present is default
        /// </summary>
        public DisplayType Display { get; set; } = DisplayType.compact;

        /// <summary>
        /// Replace the links in the bottom bar
        /// NOTE: Terms & Privacy are still manadory and must be manually replaced
        /// </summary>
        public List<Link>? SubLinks { get; set; }
    }
}
