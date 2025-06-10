using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GCDS.NetTemplate.Utils
{
    public static class ViewDataDictionaryExtensions
    {
        public static ITemplateBase? GetITemplate(this ViewDataDictionary viewData, string key = Constants.TEMPLATE_DATA) => viewData[key] as ITemplateBase;

        public static T? GetTemplate<T>(this ViewDataDictionary viewData, string key = Constants.TEMPLATE_DATA) where T : class, ITemplateBase => viewData[key] as T;        
    }
}
