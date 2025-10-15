﻿using GCDS.NetTemplate.Core;

namespace GCDS.NetTemplate.Components
{
    public class ExtAppHeader
    {
        /// <summary>
        /// Provides information for the skip to content link
        /// Automatically set for the current language
        /// </summary>
        public ExtSkipTo SkipToMainContent { get; set; } = new ExtSkipTo()
        {
            Link = new GcdsLink(
                $"#{CommonConstants.SKIP_TO_CONTENT_ID}",
                Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en"
                    ? CommonConstants.SKIP_TO_TEXT_EN
                    : CommonConstants.SKIP_TO_TEXT_FR)
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
