using GC.WebTemplate.GCDS.Components;
using GC.WebTemplate.GCDS.Utils;

namespace GC.WebTemplate.GCDS.Models
{
    public class WebTemplateModel : IWebTemplateModel
    {
        public string LanguageToggleHref { get; set; }

        public string Lang { get; set; } = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

        /// <summary>
        /// title of page
        /// Set by application programmatically
        /// </summary>
        public string PageTitle { get; set; } = string.Empty;

        private string _gcdsPath = "https://cdn.design-system.alpha.canada.ca/@cdssnc/gcds-components@";
        public string GCDSPath
        {
            get
            {
                return _gcdsPath + GCDSVersion;
            }
            set
            {
                _gcdsPath = value;
            }
        }

        /// <summary>
        /// version of GC Design System that should be targeted
        /// will target 'latest' if not set
        /// </summary>
        public string GCDSVersion { get; set; } = "latest";

        public Header Header { get; } = new Header();
        public Footer Footer { get; } = new Footer(); 
    }
}
