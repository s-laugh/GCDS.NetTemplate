using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GCDS.NetTemplate.Utils
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the TemplateAccessor and appropreate Filter to the DI container, and will register the filter globally
        /// </summary>
        /// <param name="services">service collection to return againts</param>
        /// <param name="filter">the filter to be loaded</param>
        /// <param name="global">optional pass false to register filter only on selected controlers, required true for razor</param>
        /// <returns>service collection enabling chaining functions</returns>
        public static IServiceCollection AddTemplateServices(
            this IServiceCollection services, 
            Type filter,
            Type? defaultTemplateType = null,
            bool global = true)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.TryAddScoped<ITemplateRegister, TemplateRegister>();
            TemplateRegister.DefaultTemplateType = defaultTemplateType;
            services.TryAddScoped(filter);

            if (global)
            {
                services.Configure<MvcOptions>(options =>
                {
                    options.Filters.AddService(filter);
                });
            }

            return services;
        }
        /// <summary>
        /// Add the TemplateAccessor and TemplateActionFilter to the DI container, and will register the filter globally
        /// </summary>
        /// <param name="services">service collection to return againts</param>
        /// <param name="global">optional pass false to register filter only on selected controlers, required true for razor</param>
        /// <returns>service collection enabling chaining functions</returns>
        public static IServiceCollection AddMvcTemplateServices(
            this IServiceCollection services,
            Type? defaultTemplateType = null,
            bool global = true)
        {
            return AddTemplateServices(services, typeof(TemplateActionFilter), defaultTemplateType, global);
        }
        /// <summary>
        /// Add the TemplateAccessor and TemplatePageFilter to the DI container, and will register the filter globally
        /// </summary>
        /// <param name="services">service collection to return againts</param>
        /// <param name="global">optional pass false to register filter only on selected controlers, required true for razor</param>
        /// <returns>service collection enabling chaining functions</returns>
        public static IServiceCollection AddRazorTemplateServices(
            this IServiceCollection services,
            Type? defaultTemplateType = null)
        {
            return AddTemplateServices(services, typeof(TemplatePageFilter), defaultTemplateType);
        }

        /// <summary>
        /// Configure the localization for enabling the templates default settings for language toggle
        /// </summary>
        /// <param name="services">service collection to return againts</param>
        /// <returns>service collection enabling chaining functions</returns>
        public static IServiceCollection ConfigureTemplateCulture(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = CultureConfiguration.DefaultRequestCulture;
                options.SupportedCultures = CultureConfiguration.SupportedCultures;
                options.SupportedUICultures = CultureConfiguration.SupportedCultures;
                options.RequestCultureProviders.Insert(0, new TemplateCultureProvider());
            });

            return services;
        }
    }
}
