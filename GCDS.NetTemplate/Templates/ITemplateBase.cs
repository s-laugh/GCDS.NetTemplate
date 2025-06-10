using GCDS.NetTemplate.Utils;

namespace GCDS.NetTemplate.Templates
{
    public interface ITemplateBase
    {
        TemplateSettings Settings { get; set; }

        string LanguageToggleHref { get; set; }

        string Lang { get; set; }

        string PageTitle { get; set; }

        List<HeadElement> HeadElements { get; set; }
    }
}
