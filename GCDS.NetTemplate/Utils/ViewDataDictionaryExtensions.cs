using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GCDS.NetTemplate.Utils
{
    public static class ViewDataDictionaryExtensions
    {
        public static ITemplate? GetITemplate(this ViewDataDictionary viewData, string key = Constants.TEMPLATE_DATA) => viewData[key] as ITemplate;

        public static T? GetTemplate<T>(this ViewDataDictionary viewData, string key = Constants.TEMPLATE_DATA) where T : class, ITemplate => viewData[key] as T;        
    }
}
