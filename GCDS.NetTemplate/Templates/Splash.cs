using GCDS.NetTemplate.Components;

namespace GCDS.NetTemplate.Templates
{
    public class Splash(TemplateSettings settings) : TemplateBase(settings), ITemplateBase
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
        public GcdsLink TermsEn { get; set; } = new GcdsLink
        {
            Text = "Terms & conditions",
            Href = "https://www.canada.ca/en/transparency/terms.html"
        };

        /// <summary>
        /// French link to terms and conditions (only Text & Href are used)
        /// Defaults set to canada.ca
        /// </summary>
        public GcdsLink TermsFr { get; set; } = new GcdsLink
        {
            Text = "Avis",
            Href = "https://www.canada.ca/fr/transparency/avis.html"
        };

        public GcdsSignature TopSignature { get; set; } = new GcdsSignature();

        public GcdsSignature BottomSignature { get; set; } = new GcdsSignature
        {
            Type = GcdsSignature.SignatureType.wordmark
        };

        // Do nothing, this layout doesn't use a toggle
        public override void SetLanguageToggleHref(string href) { }
    }
}
