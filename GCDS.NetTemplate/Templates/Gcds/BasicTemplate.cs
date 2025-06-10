using GCDS.NetTemplate.Components.Gcds;
using System.Reflection;

namespace GCDS.NetTemplate.Templates.Gcds
{
    public class BasicTemplate(TemplateSettings settings) : Template(settings), ITemplate
    {
        /// <summary>
        /// Loading all the configurations for the header component
        /// </summary>
        public GcdsHeader Header { get; } = new GcdsHeader()
        {
            Search = new GcdsSearch(),
            Breadcrumb = new GcdsBreadcrumbs()
        };

        /// <summary>
        /// Loading all the configurations for the footer component
        /// </summary>
        public GcdsFooter Footer { get; } = new GcdsFooter()
        {
            Display = GcdsFooter.DisplayType.full
        };

        /// <summary>
        /// Apply a last modified date or version number
        /// Will atomatically grab the last date your dll was compiled.
        /// </summary>
        public GcdsDateModified DateModified { get; set; } = new GcdsDateModified()
        {
            // get the date changed of the project that started (impemented this package)
            Text = File.GetLastWriteTime(Assembly.GetEntryAssembly()?.Location ?? string.Empty).ToString("MMMM dd, yyyy")
        };
    };
}
