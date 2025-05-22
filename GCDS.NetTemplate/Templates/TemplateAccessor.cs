namespace GCDS.NetTemplate.Templates
{
    public class TemplateAccessor(IConfiguration configuration) : ITemplateAccessor
    {
        private readonly TemplateSettings _settings = configuration.GetSection("TemplateSettings").Get<TemplateSettings>() ?? new TemplateSettings();

        public ITemplate CreateTemplate(Type templateType)
        {
            return Activator.CreateInstance(templateType, _settings) as ITemplate ?? throw new InvalidOperationException($"Cannot create instance of {templateType}");
        }
    }
}
