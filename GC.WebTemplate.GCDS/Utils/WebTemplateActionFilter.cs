using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web;

namespace GC.WebTemplate.GCDS.Utils
{
    public class WebTemplateActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Set the default values for the model
            if (context.Controller is Controller controller)
            {
                if (controller.HttpContext.RequestServices.GetService(typeof(IWebTemplateModelAccessor)) is not IWebTemplateModelAccessor modelAccessor)
                {
                    throw new InvalidOperationException("Model accessor not found in the service collection.");
                }
                var webTemplateModel = modelAccessor.Model;

                webTemplateModel.LanguageToggleHref = 
                    CultureConfiguration.BuildLanguageToggleHref(HttpUtility.ParseQueryString(controller.HttpContext.Request.QueryString.ToString()));

                controller.ViewData["WebTemplateModel"] = webTemplateModel;
            }

            base.OnActionExecuting(context);
        }
    }
}
