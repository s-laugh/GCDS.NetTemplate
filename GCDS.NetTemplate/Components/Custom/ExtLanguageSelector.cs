using GCDS.NetTemplate.Utils;
using System.Diagnostics.CodeAnalysis;

namespace GCDS.NetTemplate.Components.Custom
{
    [method: SetsRequiredMembers]
    public class ExtLanguageSelector(string enTitle, string frTitle, string href) : CommonProps
    {
        public required string EnglishTitle { get; set; } = enTitle;
        public required string FrenchTitle { get; set; } = frTitle;
        public required string HomePageHref { private get; set; } = href;
        public string EnglishHref => $"{HomePageHref}?{Constants.QUERYSTRING_CULTURE_KEY}={Constants.ENGLISH_CULTURE}";
        public string FrenchHref => $"{HomePageHref}?{Constants.QUERYSTRING_CULTURE_KEY}={Constants.FRENCH_CULTURE}";
    }
}
