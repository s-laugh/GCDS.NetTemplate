using GCDS.NetTemplate.Utils;

namespace GCDS.NetTemplate.Components.Custom
{
    public class InternalAppHeader
    {

        /// <summary>
        /// Sets the title of the site (or application)
        /// </summary>
        public required ILink SiteTitle { get; set; }

        /// <summary>
        /// Provides information for the skip to content link
        /// Automatically set for the current language
        /// </summary>
        public SkipTo SkipTo { get; set; } = new SkipTo();

        /// <summary>
        /// Enables the user to provide limited custom styling for the header
        /// </summary>
        public string? StyleOverride { get; set; }

    }

    public class SkipTo
    {

        private string? _airiaLabel;
        /// <summary>
        /// Accessibility label for the skip to content link
        /// </summary>
        public string AiriaLabel
        {
            get
            {
                return _airiaLabel ?? (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en"
                    ? Constants.SKIP_TO_AIRIA_LABEL_EN
                    : Constants.SKIP_TO_AIRIA_LABEL_FR);
            }
            set
            {
                _airiaLabel = value;
            }
        }

        private string? _text;
        /// <summary>
        /// Text for the skip to content link
        /// </summary>
        public string Text
        {
            get
            {
                return _text ??
                    (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en"
                        ? Constants.SKIP_TO_TEXT_EN
                        : Constants.SKIP_TO_TEXT_FR);
            }
            set
            {
                _text = value;
            }
        }

    }
}
