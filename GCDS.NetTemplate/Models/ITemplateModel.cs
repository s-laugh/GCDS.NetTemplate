using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Utils;

namespace GCDS.NetTemplate.Models
{
    public interface ITemplateModel
    {
        ITemplateSettings TemplateSettings { get; set; }

        string LanguageToggleHref { get; set; }
        string Lang { get; set; }

        /// <summary>
        /// title of page
        /// </summary>
        string PageTitle { get; set; }
        
        Link? SiteTitle { get; set; }


        Header Header { get; }
        Footer Footer { get; }
    }
}
