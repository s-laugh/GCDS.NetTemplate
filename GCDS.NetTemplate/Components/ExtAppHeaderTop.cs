namespace GCDS.NetTemplate.Components
{
    public class ExtAppHeaderTop
    {
        /// <summary>
        /// Language toogle link
        /// Will be set inside the layout from the Template
        /// </summary>
        public required GcdsLangToggle LanguageToggle { get; set; }

        /// <summary>
        /// Sets the title of the site (or application)
        /// </summary>
        public required ExtSiteTitle SiteTitle { get; set; }

        /// <summary>
        /// Enables limited custom styling for the header
        /// </summary>
        public string? StyleOverride { get; set; }
    }
}
