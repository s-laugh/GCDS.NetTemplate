using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GCDS.NetTemplate.Core
{
    public interface ITemplateRegister
    {
        void RegisterTemplate(ViewDataDictionary viewData, HttpContext context, IEnumerable<TemplateTypeAttribute>? templateAttr);
    }
}
