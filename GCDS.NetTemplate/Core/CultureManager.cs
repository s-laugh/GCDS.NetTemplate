using Microsoft.AspNetCore.Localization;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;

namespace GCDS.NetTemplate.Core
{
    public static class CultureManager
    {
        public static List<CultureInfo> SupportedCultures { get; set; } =
        [
            new CultureInfo(CommonConstants.ENGLISH_CULTURE),
            new CultureInfo(CommonConstants.FRENCH_CULTURE)
        ];

        public static RequestCulture DefaultRequestCulture { get; set; } =
            new RequestCulture(SupportedCultures[0]);

        public static string BuildLanguageToggleHref(NameValueCollection nameValues)
        {
            if (nameValues == null) throw new ArgumentNullException(nameof(nameValues));

            nameValues.Set(CommonConstants.QUERYSTRING_CULTURE_KEY,
                Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.StartsWith(CommonConstants.ENGLISH_CULTURE_TWO_LETTER,
                    StringComparison.OrdinalIgnoreCase)
                    ? CommonConstants.FRENCH_CULTURE
                    : CommonConstants.ENGLISH_CULTURE);

            StringBuilder buff = new(256);
            char seperator = '?';

            foreach (string key in nameValues.Keys)
            {
                buff.Append(seperator);
                buff.Append(Uri.EscapeDataString(key));
                buff.Append('=');
                buff.Append(Uri.EscapeDataString(nameValues[key]));
                seperator = '&';
            }

            return buff.ToString();
        }

        public static void SetTemplateCulture(this HttpContext httpContext, string cultureName)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            httpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureName)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
        }
    }
}
