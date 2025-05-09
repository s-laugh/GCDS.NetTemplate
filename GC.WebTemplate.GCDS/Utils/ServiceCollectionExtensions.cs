using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GC.WebTemplate.GCDS.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWebTemplateModelAccessor(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.TryAdd(ServiceDescriptor.Scoped<IWebTemplateModelAccessor, WebTemplateModelAccessor>());
        }

        public static void ConfigureWebTemplateCulture(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = CultureConfiguration.DefaultRequestCulture;
                options.SupportedCultures = CultureConfiguration.SupportedCultures;
                options.SupportedUICultures = CultureConfiguration.SupportedCultures;
                options.RequestCultureProviders.Insert(0, new WebTemplateCultureProvider());
            });
        }
    }
}
