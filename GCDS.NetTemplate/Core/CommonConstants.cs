﻿namespace GCDS.NetTemplate.Core
{
    public static class CommonConstants
    {
        public const string QUERYSTRING_CULTURE_KEY = "TemplateCulture";
        public const string ENGLISH_CULTURE = "en-CA";
        public const string FRENCH_CULTURE = "fr-CA";
        public const string ENGLISH_CULTURE_TWO_LETTER = "en";
        public const string FRENCH_CULTURE_TWO_LETTER = "fr";

        public const string TEMPLATE_DATA = "Template";

        public const string SKIP_TO_CONTENT_ID = "main-content";
        public const string SKIP_TO_AIRIA_LABEL_EN = "Skip To";
        public const string SKIP_TO_AIRIA_LABEL_FR = "Passer au";
        public const string SKIP_TO_TEXT_EN = "Skip to main content";
        public const string SKIP_TO_TEXT_FR = "Passer au contenu principal";

        public const string ERRMSG_LOAD_TEMPLATE = "Must call Add[Mvc/Razor]TemplateServices in Program.cs, and verify the template is loaded to the ViewData to use this layout.";
    }
}
