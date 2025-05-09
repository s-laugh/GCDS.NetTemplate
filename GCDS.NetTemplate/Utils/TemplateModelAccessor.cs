using GCDS.NetTemplate.Models;

namespace GCDS.NetTemplate.Utils
{
    public class TemplateModelAccessor : ITemplateModelAccessor
    {
        public ITemplateModel Model { get; }

        public TemplateModelAccessor()
        {
            Model = new TemplateModel();
        }
    }
}
