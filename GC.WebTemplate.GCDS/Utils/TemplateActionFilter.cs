using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web;

namespace GCDS.NetTemplate.Utils
{
    public class TemplateActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Set the default values for the model
            if (context.Controller is Controller controller)
            {
                if (controller.HttpContext.RequestServices.GetService(typeof(ITemplateModelAccessor)) is not ITemplateModelAccessor modelAccessor)
                {
                    throw new InvalidOperationException("Model accessor not found in the service collection.");
                }
                var webTemplateModel = modelAccessor.Model;

                webTemplateModel.LanguageToggleHref = 
                    CultureConfiguration.BuildLanguageToggleHref(HttpUtility.ParseQueryString(controller.HttpContext.Request.QueryString.ToString()));

                controller.ViewData[Constants.TEMPLATE_MODEL] = webTemplateModel;
            }

            base.OnActionExecuting(context);
        }
    }
}
