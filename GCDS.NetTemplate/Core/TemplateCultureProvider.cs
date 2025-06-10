using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace GCDS.NetTemplate.Core
{
    public class TemplateCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult?> DetermineProviderCultureResult(HttpContext httpContext)
        {
            ArgumentNullException.ThrowIfNull(httpContext);

            var locOptions = httpContext.RequestServices.GetService<IOptions<RequestLocalizationOptions>>();
            if (locOptions == null) throw new ArgumentNullException(nameof(locOptions));

            var cultureQuery = httpContext.Request.Query[Constants.QUERYSTRING_CULTURE_KEY];

            if (!string.IsNullOrEmpty(cultureQuery))
            {
                var requestedCultureName = cultureQuery.ToString();

                // Check if the request culture is part of the authorized one.
                var requestedCulture = locOptions.Value.SupportedCultures?.FirstOrDefault(x => x.Name.ToUpper() == requestedCultureName.ToUpper());

                if (requestedCulture == null)
                {
                    requestedCultureName = locOptions.Value.DefaultRequestCulture.Culture.Name.ToString();
                }

                httpContext.SetTemplateCulture(requestedCultureName);

                return Task.FromResult(new ProviderCultureResult(requestedCultureName));
            }

            return Task.FromResult(null as ProviderCultureResult);
        }
    }
}
