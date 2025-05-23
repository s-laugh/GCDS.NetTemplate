using GCDS.NetTemplate.Templates.Gcds;
using GCDS.NetTemplate.Utils;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Web;

namespace GCDS.NetTemplate.Templates
{
    public class TemplateAccessor(IConfiguration configuration) : ITemplateAccessor
    {
        // Load template settings from appsettings.json, or set to defaults
        private readonly TemplateSettings _settings = configuration.GetSection("TemplateSettings").Get<TemplateSettings>() 
            ?? new TemplateSettings();

        /// <summary>
        /// Set a global default template type
        /// </summary>
        public static Type? DefaultTemplateType { get; set; }

        /// <summary>
        /// Set up the template to be used for the current request and apply it to the view data
        /// </summary>
        /// <param name="viewData">Poperty of the ViewData where the template can be set and stored for the request</param>
        /// <param name="context">Context of the request used for configuring language toggle</param>
        /// <param name="templateAttr">Enable override of default template type</param>
        /// <exception cref="InvalidOperationException">Failed to create template of specified type</exception>
        public void SetTemplate(ViewDataDictionary viewData, HttpContext context, IEnumerable<TemplateTypeAttribute>? templateAttr)
        {
            var templateType = templateAttr?.FirstOrDefault()?.TemplateType 
                ?? DefaultTemplateType 
                ?? typeof(BasicTemplate);

            var template = Activator.CreateInstance(templateType, _settings) as ITemplate 
                ?? throw new InvalidOperationException($"Cannot create instance of {templateType}");

            template.LanguageToggleHref = CultureConfiguration.BuildLanguageToggleHref(
                HttpUtility.ParseQueryString(context.Request.QueryString.ToString()));

            viewData[Constants.TEMPLATE_DATA] = template;
        }
    }
}
