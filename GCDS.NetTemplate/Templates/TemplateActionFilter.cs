using GCDS.NetTemplate.Templates.Gcds;
using GCDS.NetTemplate.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using System.Web;

namespace GCDS.NetTemplate.Templates
{
    public class TemplateActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Set the default values for the model
            if (context.Controller is Controller controller)
            {
                if (controller.HttpContext.RequestServices.GetService(typeof(ITemplateAccessor)) is not ITemplateAccessor accessor)
                {
                    throw new InvalidOperationException("Accessor not found in the service collection.");
                }

                var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
                var templateAttr = 
                    descriptor?.MethodInfo.GetCustomAttributes<TemplateTypeAttribute>() ?? 
                    descriptor?.ControllerTypeInfo.GetCustomAttributes<TemplateTypeAttribute>();
                var templateType = templateAttr?.FirstOrDefault()?.TemplateType ?? typeof(BasicTemplate); // fallback
                var template = accessor.CreateTemplate(templateType);

                template.LanguageToggleHref =
                    CultureConfiguration.BuildLanguageToggleHref(HttpUtility.ParseQueryString(controller.HttpContext.Request.QueryString.ToString()));

                controller.ViewData[Constants.TEMPLATE_DATA] = template;
            }

            base.OnActionExecuting(context);
        }
    }
}
