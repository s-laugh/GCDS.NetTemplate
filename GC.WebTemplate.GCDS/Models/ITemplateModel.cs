using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Utils;

namespace GCDS.NetTemplate.Models
{
    public interface ITemplateModel
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
