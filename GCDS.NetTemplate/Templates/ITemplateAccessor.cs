namespace GCDS.NetTemplate.Templates
{
    public interface ITemplateAccessor
    {
        ITemplate CreateTemplate(Type templateType);
    }
}
