namespace GCDS.NetTemplate.Components.Custom
{
    public class ExtSiteTitle
    {
        /// <summary>
        /// Text to display as the site or application title
        /// </summary>
        public required string Text { get; set; }

        /// <summary>
        /// An optional link to apply to the title
        /// </summary>
        public string? Href { get; set; }

        /// <summary>
        /// Optional sytle overrides for customization
        /// </summary>
        public string? StyleOverride { get; set; }
    }
}
