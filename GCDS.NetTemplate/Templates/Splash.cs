using GCDS.NetTemplate.Components;

namespace GCDS.NetTemplate.Templates
{
    public class Splash(TemplateSettings settings, HttpContext context) 
        : TemplateBase(settings, context)
    {        
        /// <summary>
        /// Set links to the splash images that will be randomly selcted to be used in the splash screen.
        /// Defaults set to canada.ca
        /// </summary>
        public IEnumerable<string> SplashImages { get; set; } = [
            "https://www.canada.ca/content/dam/canada/splash/sp-bg-1.jpg",
            "https://www.canada.ca/content/dam/canada/splash/sp-bg-2.jpg",
            "https://www.canada.ca/content/dam/canada/splash/sp-bg-3.jpg",
            "https://www.canada.ca/content/dam/canada/splash/sp-bg-4.jpg",
            "https://www.canada.ca/content/dam/canada/splash/sp-bg-5.jpg"
        ];

        /// <summary>
        /// Setup the language selector component with titles and a link.
        /// </summary>
        public required ExtLanguageSelector LanguageSelector { get; set; }

        /// <summary>
        /// English link to terms and conditions (only Text & Href are used).
        /// Defaults set to canada.ca
        /// </summary>
        public GcdsLink TermsEn { get; set; } = new GcdsLink("https://www.canada.ca/en/transparency/terms.html", "Terms & conditions");

        /// <summary>
        /// French link to terms and conditions (only Text & Href are used)
        /// Defaults set to canada.ca
        /// </summary>
        public GcdsLink TermsFr { get; set; } = new GcdsLink("https://www.canada.ca/fr/transparency/avis.html", "Avis");

        public GcdsSignature TopSignature { get; set; } = new GcdsSignature();

        public GcdsSignature BottomSignature { get; set; } = new GcdsSignature
        {
            Type = GcdsSignature.SignatureType.wordmark
        };

        public Splash Inizialize(string pageTitle, string englishTitle, string frenchTitle, string href)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(englishTitle);
            ArgumentException.ThrowIfNullOrWhiteSpace(frenchTitle);
            ArgumentException.ThrowIfNullOrWhiteSpace(href);
            return Inizialize(pageTitle, new ExtLanguageSelector(englishTitle, frenchTitle, href));
        }
        public Splash Inizialize(string pageTitle, ExtLanguageSelector languageSelector)
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
