using GCDS.NetTemplate.Components.Gcds;

namespace GCDS.NetTemplate.Templates.Gcds
{
    public class BasicTemplate(TemplateSettings settings) : Template(settings), ITemplate
    {
        /// <summary>
        /// Loading all the configurations for the header component
        /// </summary>
        public Header Header { get; } = new Header()
        {
            Search = new Search(),
            Breadcrumb = new Breadcrumbs()
        };

        /// <summary>
        /// Loading all the configurations for the footer component
        /// </summary>
        public Footer Footer { get; } = new Footer()
        {
            Display = Footer.DisplayType.full
        };
    }
}
