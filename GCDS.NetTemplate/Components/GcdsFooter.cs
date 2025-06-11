namespace GCDS.NetTemplate.Components
{
    /// <summary>
    /// Class holder for the footer properties as defined in the GCDS template
    /// https://design-system.alpha.canada.ca/en/components/footer/
    /// </summary>
    public class GcdsFooter : CommonProps
    {
        public enum DisplayType
        {
            compact,
            full
        }

        /// <summary>
        /// A Title for the custom heading to be displayed in the footer
        /// </summary>
        public string? ContextualHeading { get; set; }

        /// <summary>
        /// A list of contextual links to be displayed in the footer
        /// GCDS will only display the first 3 links
        /// </summary>
        public IEnumerable<GcdsLink>? ContextualLinks { get; set; }

        /// <summary>
        /// Toggles the Government of Canada pre-set links
        /// </summary>
        public DisplayType Display { get; set; } = DisplayType.compact;

        /// <summary>
        /// Overrides the bottom links if any are provied
        /// Terms and conditions and Privacy links should be re-added manually.
        /// </summary>
        public IEnumerable<GcdsLink>? SubLinks { get; set; }

        /// <summary>
        /// Enables the user to provide limited custom styling for overriding the footer defaults
        /// Will be injected as in-line CSS
        /// </summary>
        public string? StyleOverride { get; set; }
    }
}
