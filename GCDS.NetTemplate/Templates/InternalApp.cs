using GCDS.NetTemplate.Components;
using System.Diagnostics;
using System.Reflection;

namespace GCDS.NetTemplate.Templates
{
    public class InternalApp(TemplateSettings settings, HttpContext context) 
        : TemplateBase(settings, context)
    {
        /// <summary>
        /// Loading all the configurations for the header component
        /// </summary>
        public ExtAppHeader? Header { get; set; }

        /// <summary>
        /// Loading all the configurations for the footer component
        /// </summary>
        public GcdsFooter Footer { get; set; } = new GcdsFooter();

        /// <summary>
        /// Apply a last modified date or version number
        /// Will automatically grab the version from your dll.
        /// </summary>
        public GcdsDateModified DateModified { get; set; } = new GcdsDateModified()
        {
            // get the version number of the project that started (implemented this package) and trim any trailing zeros from the version
            Text = string.Join(".",
                (FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly()?.Location ?? string.Empty).FileVersion ?? string.Empty)
                .Split('.').Reverse().SkipWhile(s => s == "0").Reverse()),
            Type = GcdsDateModified.DateModifiedType.version
        };

        public string LangToggleHref { get; set; } = "";
        public override void SetLanguageToggleHref(string href)
            => LangToggleHref = href ?? throw new ArgumentNullException(nameof(href));

        public InternalApp Initialize(string pageTitle, string siteTitle)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(siteTitle);
            return Initialize(pageTitle, new ExtSiteTitle { Text = siteTitle });
        }
        public InternalApp Initialize(string pageTitle, ExtSiteTitle siteTitle)
        {
            base.Initialize(pageTitle);
            ArgumentNullException.ThrowIfNull(siteTitle);
            Header = new ExtAppHeader {
                AppHeaderTop = new ExtAppHeaderTop
                {
                    LanguageToggle = new GcdsLangToggle { Href = LangToggleHref },
                    SiteTitle = siteTitle
                }
            };
            return this;
        }        
    }
}
