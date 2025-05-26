using GCDS.NetTemplate.Components.Gcds;
using System.Reflection;

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

        public DateModified DateModified { get; set; } = new DateModified()
        {

            // get the date changed of the project that started (impemented this package)
            Text = File.GetLastWriteTime(Assembly.GetEntryAssembly()?.Location ?? string.Empty).ToString("MMMM dd, yyyy")
        };
    };
}
