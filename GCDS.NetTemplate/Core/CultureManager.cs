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
            new CultureInfo(Constants.ENGLISH_CULTURE),
            new CultureInfo(Constants.FRENCH_CULTURE)
        ];

        public static RequestCulture DefaultRequestCulture { get; set; } =
            new RequestCulture(SupportedCultures[0]);

        public static string BuildLanguageToggleHref(NameValueCollection nameValues)
        {
            if (nameValues == null) throw new ArgumentNullException(nameof(nameValues));

            nameValues.Set(Constants.QUERYSTRING_CULTURE_KEY,
                Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.StartsWith(Constants.ENGLISH_CULTURE_TWO_LETTER,
                    StringComparison.OrdinalIgnoreCase)
                    ? Constants.FRENCH_CULTURE
                    : Constants.ENGLISH_CULTURE);

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
