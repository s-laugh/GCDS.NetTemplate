using GCDS.NetTemplate.Components.Gcds;

namespace GCDS.NetTemplate.Components.Custom
{
    public class AppHeaderTop
    {
        /// <summary>
        /// Language toogle link
        /// Will be set inside the layout from the Template
        /// </summary>
        public LangToggle LanguageToggle { get; set; } = new LangToggle() { Href = string.Empty };

        /// <summary>
        /// Sets the title of the site (or application)
        /// </summary>
        public required Link SiteTitle { get; set; }

        /// <summary>
        /// Enables limited custom styling for the header
        /// </summary>
        public string? StyleOverride { get; set; }
    }
}
