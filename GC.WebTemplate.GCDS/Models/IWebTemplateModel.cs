namespace GC.WebTemplate.GCDS.Models
{
    public interface IWebTemplateModel
    {
        /// <summary>
        /// Retreive the first 2 letters of the current culture "en" or "fr"
        /// Used by generate paths, determine language etc...
        /// Set by Template
        /// </summary>
        string TwoLetterCultureLanguage { get; }

        /// <summary>
        /// title of page
        /// </summary>
        string PageTitle { get; set; }

        string GCDSPath { get; set; }

        /// <summary>
        /// version of GC Design System that should be targeted
        /// will target 'latest' if not set
        /// </summary>
        string GCDSVersion { get; set; }

        GCDSHeaderModel Header { get; }
        GCDSFooterModel Footer { get; }
    }
}
