using GCDS.NetTemplate.Core;
using System.Diagnostics.CodeAnalysis;

namespace GCDS.NetTemplate.Components
{
    [method: SetsRequiredMembers]
    public class ExtLanguageSelector(string enTitle, string frTitle, string href) : CommonProps
    {
        public required string EnglishTitle { get; set; } = enTitle;
        public required string FrenchTitle { get; set; } = frTitle;
        public required string HomePageHref { private get; set; } = href;
        public string EnglishHref => $"{HomePageHref}?{CommonConstants.QUERYSTRING_CULTURE_KEY}={CommonConstants.ENGLISH_CULTURE}";
        public string FrenchHref => $"{HomePageHref}?{CommonConstants.QUERYSTRING_CULTURE_KEY}={CommonConstants.FRENCH_CULTURE}";
    }
}
