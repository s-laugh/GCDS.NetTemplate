using GCDS.NetTemplate.Core;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GCDS.NetTemplate.Templates
{
    public static class TemplateExtensions
    {
        public static TemplateBase? GetTemplateBase(
            this ViewDataDictionary viewData, 
            string key = CommonConstants.TEMPLATE_DATA) 
            => viewData[key] as TemplateBase;

        public static ITemplateCommon? GetTemplateCommon(
            this ViewDataDictionary viewData,
            string key = CommonConstants.TEMPLATE_DATA)
            => viewData[key] as ITemplateCommon;

        public static T? GetTemplate<T>(
            this ViewDataDictionary viewData, 
            string key = CommonConstants.TEMPLATE_DATA) 
            where T : class, ITemplateBase 
            => viewData[key] as T;        
    }
}
