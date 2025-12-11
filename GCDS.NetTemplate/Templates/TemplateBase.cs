using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Core;

namespace GCDS.NetTemplate.Templates
{
    public interface ITemplateBase
    {
        TemplateSettings Settings { get; }
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
            SetLanguageToggleHref(context.Request.QueryString.BuildLanguageToggleQuery());
            StaticAssetsBasePath = $"{context.Request.PathBase.Value}/_content/{typeof(TemplateBase).Assembly.GetName().Name}";
            HeadElements.AddLink($"{StaticAssetsBasePath}/images/icon.png", "icon", "image/png");
            HeadElements.AddLink($"{StaticAssetsBasePath}/styles/GCDS.NetTemplate.css");
        }

        public string StaticAssetsBasePath { get; set; } 

        /// <summary>
        /// Template settings, loaded from the appsettings.json file
        /// </summary>
        public TemplateSettings Settings { get; init; }

        /// <summary>
        /// The CurrentUICulture to ensure the components load with the right language settings
        /// </summary>
        public string Lang { get; set; }
         = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

        /// <summary>
        /// title of page
        /// </summary>
        public string PageTitle { get; set; } = null!;

        public enum ViewDataAction { Replace, Prepend, Append }

        public ViewDataAction PageTitleAction { get; set; } = ViewDataAction.Replace;

        /// <summary>
        /// Creates a list of HeadElements that will be added to the head of the page.
        /// Used for adding meta tags, linking to styles or scripts.
        /// </summary>
        public List<ExtHtmlElement> HeadElements { get; set; } = [];

        public virtual TemplateBase Initialize(string pageTitle)
        {            
            ArgumentNullException.ThrowIfNull(pageTitle);
            PageTitle = pageTitle;
            return this;
        }

        /// <summary>
        /// Enables setting the toggle link for the language
        /// Set in the ActionFilter by default
        /// </summary>
        public abstract void SetLanguageToggleHref(string href);
    }
}
