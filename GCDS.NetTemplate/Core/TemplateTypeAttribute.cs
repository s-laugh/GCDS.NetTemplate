using GCDS.NetTemplate.Templates;

namespace GCDS.NetTemplate.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class TemplateTypeAttribute : Attribute
    {
        public Type TemplateType { get; }

        public TemplateTypeAttribute(Type templateType)
        {
            if (!typeof(ITemplateBase).IsAssignableFrom(templateType))
            {
                throw new ArgumentException("Type must implement ITemplate", nameof(templateType));
            }

            TemplateType = templateType;
        }

    }
}
