using GCDS.NetTemplate.Utils;
using System.Diagnostics.CodeAnalysis;

namespace GCDS.NetTemplate.Components
{
    public class ExtAppHeader
    {
        public ExtAppHeader() { }

        [SetsRequiredMembers]
        public ExtAppHeader(string siteTitleText)
        {
            AppHeaderTop = new ExtAppHeaderTop
            {
                SiteTitle = new ExtSiteTitle
                {
                    Text = siteTitleText
                }
            };
        }

        [SetsRequiredMembers]
        public ExtAppHeader(ExtSiteTitle siteTitle)
        {
            AppHeaderTop = new ExtAppHeaderTop { SiteTitle = siteTitle };
        }

        /// <summary>
        /// Provides information for the skip to content link
        /// Automatically set for the current language
        /// </summary>
        public ExtSkipTo SkipToMainContent { get; set; } = new ExtSkipTo()
        {
            Link = new GcdsLink
            {
                Text = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en"
                    ? Constants.SKIP_TO_TEXT_EN
                    : Constants.SKIP_TO_TEXT_FR,
                Href = $"#{Constants.SKIP_TO_CONTENT_ID}",
            }
        };

        /// <summary>
        /// Provides information for the top section of the header
        /// </summary>
        public required ExtAppHeaderTop AppHeaderTop { get; set; }

        /// <summary>
        /// Enables implementing a Menu with the TopNav component
        /// </summary>
        public GcdsTopNav? Menu { get; set; }

        /// <summary>
        /// Enables implementing a Breadcrumbs component
        /// </summary>
        public GcdsBreadcrumbs? Breadcrumbs { get; set; }
    }
}
