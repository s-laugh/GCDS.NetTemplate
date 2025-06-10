using GCDS.NetTemplate.Components;

namespace GCDS.NetTemplate.Templates
{
    public class TemplateBase(TemplateSettings settings)
    {
        /// <summary>
        /// Template settings, loaded from the appsettings.json file
        /// </summary>
        public TemplateSettings Settings { get; set; } = settings;

        /// <summary>
        /// Toogle link for the language
        /// Set in the ActionFilter
        /// Passt to Header element, stored here for customization
        /// </summary>
        public required string LanguageToggleHref { get; set; }

        /// <summary>
        /// The CurrentUICulture to ensure the components load with the right language settings
        /// </summary>
        public string Lang { get; set; } = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

        /// <summary>
        /// title of page
        /// </summary>
        public string PageTitle { get; set; } = string.Empty;

        /// <summary>
        /// Creates a list of HeadElements that will be added to the head of the page.
        /// Used for adding meta tags, linking to styles or scripts.
        /// </summary>
        public List<ExtHeadElement> HeadElements { get; set; } = [];
    }
}
