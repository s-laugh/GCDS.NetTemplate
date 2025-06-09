using GCDS.NetTemplate.Components.Custom;
using GCDS.NetTemplate.Components.Gcds;

namespace GCDS.NetTemplate.Templates.Custom
{
    public class SplashTemplate(TemplateSettings settings) : Template(settings), ITemplate
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
        public required LanguageSelector LanguageSelector { get; set; }

        /// <summary>
        /// English link to terms and conditions (only Text & Href are used).
        /// Defaults set to canada.ca
        /// </summary>
        public Link TermsEn { get; set; } = new Link
        {
            Text = "Terms & conditions",
            Href = "https://www.canada.ca/en/transparency/terms.html"
        };

        /// <summary>
        /// French link to terms and conditions (only Text & Href are used)
        /// Defaults set to canada.ca
        /// </summary>
        public Link TermsFr { get; set; } = new Link
        {
            Text = "Avis",
            Href = "https://www.canada.ca/fr/transparency/avis.html"
        };

        public Signature TopSignature { get; set; } = new Signature();

        public Signature BottomSignature { get; set; } = new Signature
        {
            Type = Signature.SignatureType.wordmark
        };
    }
}
