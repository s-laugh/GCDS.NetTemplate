using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GCDS.NetTemplate.Core
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the TemplateAccessor and appropriate Filter to the DI container, and will register the filter globally
        /// </summary>
        /// <param name="builder">the root WebApplicationBuilder</param>
        /// <param name="filter">the filter to be loaded</param>
        /// <param name="global">optional pass false to register filter only on selected controllers, required true for razor</param>
        /// <returns>service collection enabling chaining functions</returns>
        public static IServiceCollection AddTemplateServices(
            this WebApplicationBuilder builder,
            Type filter,
            Type? defaultTemplateType = null,
            bool global = true)
        {

            builder.Services.TryAddScoped<IInitializer, Initializer>();
            Initializer.DefaultTemplateType = defaultTemplateType;
            builder.Services.TryAddScoped(filter);

            if (global)
            {
                builder.Services.Configure<MvcOptions>(options =>
                {
                    options.Filters.AddService(filter);
                });
            }
            builder.WebHost.UseStaticWebAssets();

            return builder.Services;
        }
        /// <summary>
        /// Add the TemplateAccessor and TemplateActionFilter to the DI container, and will register the filter globally
        /// </summary>
        /// <param name="builder">the root WebApplicationBuilder</param>
        /// <param name="global">optional pass false to register filter only on selected controllers, required true for razor</param>
        /// <returns>service collection enabling chaining functions</returns>
        public static IServiceCollection AddMvcTemplateServices(
            this WebApplicationBuilder builder,
            Type? defaultTemplateType = null,
            bool global = true)
            => builder.AddTemplateServices(typeof(TemplateActionFilter), defaultTemplateType, global);

        /// <summary>
        /// Add the TemplateAccessor and TemplatePageFilter to the DI container, and will register the filter globally
        /// </summary>
        /// <param name="builder">the root WebApplicationBuilder</param>
        /// <param name="global">optional pass false to register filter only on selected controllers, required true for razor</param>
        /// <returns>service collection enabling chaining functions</returns>
        public static IServiceCollection AddRazorTemplateServices(
            this WebApplicationBuilder builder,
            Type? defaultTemplateType = null)
            => builder.AddTemplateServices(typeof(TemplatePageFilter), defaultTemplateType);

        /// <summary>
        /// Configure the localization for enabling the templates default settings for language toggle
        /// </summary>
        /// <param name="services">service collection to return against</param>
        /// <returns>service collection enabling chaining functions</returns>
        public static IServiceCollection ConfigureTemplateCulture(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = CultureManager.DefaultRequestCulture;
                options.SupportedCultures = CultureManager.SupportedCultures;
                options.SupportedUICultures = CultureManager.SupportedCultures;
                options.RequestCultureProviders.Insert(0, new CultureProviderMiddleware());
            });

            return services;
        }
    }
}
