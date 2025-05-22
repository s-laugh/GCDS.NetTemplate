namespace GCDS.NetTemplate.Templates
{
    public interface ITemplate
    {
        TemplateSettings Settings { get; set; }

        string LanguageToggleHref { get; set; }

        string Lang { get; set; }

        string PageTitle { get; set; }
    }
}
