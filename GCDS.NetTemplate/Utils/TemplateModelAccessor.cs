using GCDS.NetTemplate.Models;

namespace GCDS.NetTemplate.Utils
{
    public class TemplateModelAccessor : ITemplateModelAccessor
    {
        public ITemplateModel Model { get; }

        public TemplateModelAccessor(IConfiguration configuration)
        {
            var settings = configuration.GetSection("TemplateSettings").Get<TemplateSettings>();

            Model = new TemplateModel(settings);
        }
    }
}
