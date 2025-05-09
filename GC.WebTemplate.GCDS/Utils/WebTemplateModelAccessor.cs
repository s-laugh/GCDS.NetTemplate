using GC.WebTemplate.GCDS.Models;

namespace GC.WebTemplate.GCDS.Utils
{
    public class WebTemplateModelAccessor : IWebTemplateModelAccessor
    {
        public IWebTemplateModel Model { get; }

        public WebTemplateModelAccessor()
        {
            Model = new WebTemplateModel();
        }
    }
}
