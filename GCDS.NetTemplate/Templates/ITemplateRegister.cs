using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GCDS.NetTemplate.Templates
{
    public interface ITemplateRegister
    {
        void RegisterTemplate(ViewDataDictionary viewData, HttpContext context, IEnumerable<TemplateTypeAttribute>? templateAttr);
    }
}
