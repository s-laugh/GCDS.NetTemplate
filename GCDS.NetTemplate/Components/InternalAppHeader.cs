using GCDS.NetTemplate.Utils;

namespace GCDS.NetTemplate.Components
{
    public class InternalAppHeader
    {

        /// <summary>
        /// Used in the custom internal layout to set the title of the site (or application)
        /// </summary>
        public required Link SiteTitle { get; set; }

        public SkipTo SkipTo { get; set; } = new SkipTo();

        /// <summary>
        /// Enables the user to provide limited custom styling for the header
        /// </summary>
        public string? StyleOverride { get; set; }

    }

    public class SkipTo
    {

        private string? _airiaLabel;
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
