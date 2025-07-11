﻿using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Web;

namespace GCDS.NetTemplate.Core
{
    public interface IInitializer
    {
        void InitializeTemplate(ViewDataDictionary viewData, HttpContext context, IEnumerable<TemplateTypeAttribute>? templateAttr);
    }

    public class Initializer : IInitializer
    {
        // Load template settings from appsettings.json, or set to defaults
        private readonly TemplateSettings _settings;

        public Initializer(IConfiguration configuration)
        {
            _settings = new TemplateSettings();
            configuration.GetSection("TemplateSettings").Bind(_settings);
        }

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
        public void InitializeTemplate(ViewDataDictionary viewData, HttpContext context, IEnumerable<TemplateTypeAttribute>? templateAttr)
        {
            var templateType = templateAttr?.FirstOrDefault()?.TemplateType 
                ?? DefaultTemplateType 
                ?? typeof(Basic);

            var template = Activator.CreateInstance(templateType, _settings) as ITemplateBase 
                ?? throw new InvalidOperationException($"Cannot create instance of {templateType}");

            template.SetLanguageToggleHref(CultureManager.BuildLanguageToggleHref(
                HttpUtility.ParseQueryString(context.Request.QueryString.ToString())));

            viewData[CommonConstants.TEMPLATE_DATA] = template;
        }
    }
}
