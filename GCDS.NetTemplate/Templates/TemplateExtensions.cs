using GCDS.NetTemplate.Core;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GCDS.NetTemplate.Templates
{
    public static class TemplateExtensions
    {
        public static ITemplateBase? GetITemplate(this ViewDataDictionary viewData, string key = CommonConstants.TEMPLATE_DATA) => viewData[key] as ITemplateBase;

        public static T? GetTemplate<T>(this ViewDataDictionary viewData, string key = CommonConstants.TEMPLATE_DATA) where T : class, ITemplateBase => viewData[key] as T;        
    }
}
