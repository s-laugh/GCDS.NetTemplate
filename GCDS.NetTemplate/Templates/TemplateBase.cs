using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Core;

namespace GCDS.NetTemplate.Templates
{
    public interface ITemplateBase
    {
        TemplateSettings Settings { get; set; }

        string Lang { get; set; }

        string PageTitle { get; set; }

        List<ExtHtmlElement> HeadElements { get; set; }

        void SetLanguageToggleHref(string href);
    }

    public abstract class TemplateBase : ITemplateBase
    {
        public TemplateBase(TemplateSettings settings, HttpContext context)
        {
            Settings = settings;
            SetLanguageToggleHref(context.Request.QueryString.AddTemplateLangugeToogle());
            HeadElements.AddLink($"{context.Request.PathBase.Value}/_content/{typeof(TemplateBase).Assembly.GetName().Name}/images/icon.png", "icon", "image/png");
        }

        /// <summary>
        /// Template settings, loaded from the appsettings.json file
        /// </summary>
        public required TemplateSettings Settings { get; set; }

        /// <summary>
        /// The CurrentUICulture to ensure the components load with the right language settings
        /// </summary>
        public string Lang { get; set; }
         = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

        /// <summary>
        /// title of page
        /// </summary>
        public string PageTitle { get; set; } = null!;

        /// <summary>
        /// Creates a list of HeadElements that will be added to the head of the page.
        /// Used for adding meta tags, linking to styles or scripts.
        /// </summary>
        public List<ExtHtmlElement> HeadElements { get; set; } = new List<ExtHtmlElement>().AddLink($"/_content/{typeof(TemplateBase).Assembly.GetName().Name}/images/icon.png", "icon", "image/png");

        public virtual TemplateBase Initialize(string pageTitle)
        {            
            ArgumentNullException.ThrowIfNull(pageTitle);
            PageTitle = pageTitle;
            return this;
        }

        /// <summary>
        /// Enables settign the toogle link for the language
        /// Set in the ActionFilter by default
        /// </summary>
        public abstract void SetLanguageToggleHref(string href);
    }
}
