using GCDS.NetTemplate.Components.Gcds;
using GCDS.NetTemplate.Utils;
using System.Diagnostics.CodeAnalysis;

namespace GCDS.NetTemplate.Components.Custom
{
    public class InternalAppHeader
    {
        public InternalAppHeader() { }

        [SetsRequiredMembers]
        public InternalAppHeader(string siteTitleText)
        {
            AppHeaderTop = new AppHeaderTop
            {
                SiteTitle = new SiteTitle
                {
                    Text = siteTitleText
                }
            };
        }

        [SetsRequiredMembers]
        public InternalAppHeader(SiteTitle siteTitle)
        {
            AppHeaderTop = new AppHeaderTop { SiteTitle = siteTitle };
        }

        /// <summary>
        /// Provides information for the skip to content link
        /// Automatically set for the current language
        /// </summary>
        public SkipTo SkipToMainContent { get; set; } = new SkipTo()
        {
            Link = new Link
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
        public required AppHeaderTop AppHeaderTop { get; set; }

        /// <summary>
        /// Enables implementing a Menu with the TopNav component
        /// </summary>
        public TopNav? Menu { get; set; }

        /// <summary>
        /// Enables implementing a Breadcrumbs component
        /// </summary>
        public Breadcrumbs? Breadcrumbs { get; set; }
    }
}
