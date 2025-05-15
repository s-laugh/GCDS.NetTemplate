using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Utils;

namespace GCDS.NetTemplate.Models
{
    public class TemplateModel(TemplateSettings settings) : ITemplateModel
    {
        /// <summary>
        /// Template settings, loaded from the appsettings.json file
        /// </summary>
        public ITemplateSettings TemplateSettings { get; set; } = settings;

        /// <summary>
        /// Toogle link for the language
        /// Set in the ActionFilter
        /// Passt to Header element, stored here for customization
        /// </summary>
        public string LanguageToggleHref { get; set; }

        /// <summary>
        /// The CurrentUICulture to ensure the components load with the right language settings
        /// </summary>
        public string Lang { get; set; } = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

        /// <summary>
        /// title of page
        /// </summary>
        public string PageTitle { get; set; } = string.Empty;

        /// <summary>
        /// Used in the custom internal layout to set the title of the site (or application)
        /// </summary>
        public Link? SiteTitle { get; set; }

        /// <summary>
        /// Loading all the configurations for the header component
        /// </summary>
        public Header Header { get; } = new Header();

        /// <summary>
        /// Loading all the configurations for the footer component
        /// </summary>
        public Footer Footer { get; } = new Footer(); 
    }
}
