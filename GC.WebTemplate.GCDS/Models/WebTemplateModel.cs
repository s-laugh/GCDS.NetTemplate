using GC.WebTemplate.GCDS.Components;

namespace GC.WebTemplate.GCDS.Models
{
    public class WebTemplateModel : IWebTemplateModel
    {
        /// <summary>
        /// Retreive the first 2 letters of the current culture "en" or "fr"
        /// Used by generate paths, determine language etc...
        /// Set by Template
        /// </summary>
        public string TwoLetterCultureLanguage => Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

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

        public GCDSHeader Header { get; } = new GCDSHeader();
        public GCDSFooterModel Footer { get; } = new GCDSFooterModel(); 
    }
}
