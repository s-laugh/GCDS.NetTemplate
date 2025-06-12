using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Core;
using System.Reflection;

namespace GCDS.NetTemplate.Templates
{
    public class Basic(TemplateSettings settings) : TemplateBase(settings), ITemplateBase
    {
        /// <summary>
        /// Loading all the configurations for the header component
        /// </summary>
        public GcdsHeader Header { get; } = new GcdsHeader()
        {
            SkipToHref = $"#{CommonConstants.SKIP_TO_CONTENT_ID}",
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

        public override void SetLanguageToggleHref(string href)
            => Header.LangHref = href ?? throw new ArgumentNullException(nameof(href));
        
    };
}
