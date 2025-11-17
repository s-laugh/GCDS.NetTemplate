using GCDS.NetTemplate.Components;

namespace GCDS.NetTemplate.Templates
{
    public class Splash : TemplateBase
    { 
        
        public Splash(TemplateSettings settings, HttpContext context) : base(settings, context)
        {
            if(settings.SplashLoadsDefaultBackgroundImage)
            {
                HeadElements.AddScript($"{context.Request.PathBase.Value}/{Assets.BasePath}/scripts/LoadRandomBackground.js");
                HeadElements.AddLink($"{context.Request.PathBase.Value}/{Assets.BasePath}/styles/BackgroundCover.css");
            }
        }

        /// <summary>
        /// Setup the language selector component with titles and a link.
        /// </summary>
        public required ExtLanguageSelector LanguageSelector { get; set; }

        /// <summary>
        /// English link to terms and conditions (only Text & Href are used).
        /// Defaults set to Canada.ca
        /// </summary>
        public GcdsLink TermsEn { get; set; } = new GcdsLink("https://www.canada.ca/en/transparency/terms.html", "Terms & conditions");

        /// <summary>
        /// French link to terms and conditions (only Text & Href are used)
        /// Defaults set to Canada.ca
        /// </summary>
        public GcdsLink TermsFr { get; set; } = new GcdsLink("https://www.canada.ca/fr/transparency/avis.html", "Avis");

        public GcdsSignature TopSignature { get; set; } = new GcdsSignature();

        public GcdsSignature BottomSignature { get; set; } = new GcdsSignature
        {
            Type = GcdsSignature.SignatureType.wordmark
        };

        public Splash Initialize(string pageTitle, string englishTitle, string frenchTitle, string href)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(englishTitle);
            ArgumentException.ThrowIfNullOrWhiteSpace(frenchTitle);
            ArgumentException.ThrowIfNullOrWhiteSpace(href);
            return Initialize(pageTitle, new ExtLanguageSelector(englishTitle, frenchTitle, href));
        }
        public Splash Initialize(string pageTitle, ExtLanguageSelector languageSelector)
        {
            base.Initialize(pageTitle);
            ArgumentNullException.ThrowIfNull(languageSelector);
            LanguageSelector = languageSelector;
            return this;
        }

        // Do nothing, this layout doesn't use a toggle
        public override void SetLanguageToggleHref(string href) { }
    }
}
