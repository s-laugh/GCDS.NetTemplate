using GCDS.NetTemplate.Components.Gcds;
using GCDS.NetTemplate.Utils;

namespace GCDS.NetTemplate.Components.Custom
{
    public class InternalAppHeader
    {
        /// <summary>
        /// Language toogle link
        /// Will be set inside the layout from the Template
        /// </summary>
        public string? LanguageToggleHref { get; set; }

        /// <summary>
        /// Sets the title of the site (or application)
        /// </summary>
        public required ILink SiteTitle { get; set; }

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
        /// Enables implementing a Menu with the TopNav component
        /// </summary>
        public TopNav? Menu { get; set; }

        /// <summary>
        /// Enables limited custom styling for the header
        /// </summary>
        public string? StyleOverride { get; set; }


    }
}
