using GCDS.NetTemplate.Components;

namespace GCDS.NetTemplate.Templates
{
    public interface ITemplateBase
    {
        TemplateSettings Settings { get; set; }

        string LanguageToggleHref { get; set; }

        string Lang { get; set; }

        string PageTitle { get; set; }

        List<ExtHeadElement> HeadElements { get; set; }
    }
}
