using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GCDS.NetTemplate.Templates
{
    public interface ITemplateAccessor
    {
        void SetTemplate(ViewDataDictionary viewData, HttpContext context, IEnumerable<TemplateTypeAttribute>? templateAttr);
    }
}
