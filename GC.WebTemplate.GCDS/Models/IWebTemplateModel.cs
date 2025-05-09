using GC.WebTemplate.GCDS.Components;
using GC.WebTemplate.GCDS.Utils;

namespace GC.WebTemplate.GCDS.Models
{
    public interface IWebTemplateModel
    {
        string LanguageToggleHref { get; set; }
        string Lang { get; set; }

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

        Header Header { get; }
        Footer Footer { get; }
    }
}
