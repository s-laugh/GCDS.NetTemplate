using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GC.WebTemplate.GCDS.Utils
{
    public static class ServiceCollectionModelAccessorExtension
    {
        public static void AddModelAccessor(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAdd(ServiceDescriptor.Scoped<IWebTemplateModelAccessor, WebTemplateModelAccessor>());
        }
    }
}
