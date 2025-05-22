namespace GCDS.NetTemplate.Templates
{
    public class Template(TemplateSettings settings)
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
    }
}
