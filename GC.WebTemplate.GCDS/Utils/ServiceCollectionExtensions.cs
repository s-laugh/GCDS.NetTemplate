using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GCDS.NetTemplate.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWebTemplateModelAccessor(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.TryAdd(ServiceDescriptor.Scoped<ITemplateModelAccessor, TemplateModelAccessor>());
        }

        public static void ConfigureWebTemplateCulture(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = CultureConfiguration.DefaultRequestCulture;
                options.SupportedCultures = CultureConfiguration.SupportedCultures;
                options.SupportedUICultures = CultureConfiguration.SupportedCultures;
                options.RequestCultureProviders.Insert(0, new TemplateCultureProvider());
            });
        }
    }
}
