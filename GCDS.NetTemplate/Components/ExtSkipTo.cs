using GCDS.NetTemplate.Utils;

namespace GCDS.NetTemplate.Components
{
    public class ExtSkipTo : ISlotHeaderSkipTo
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

        /// <summary>
        /// Link to the section to skip to
        /// </summary>
        public required GcdsLink Link { get; set; }
    }
}
