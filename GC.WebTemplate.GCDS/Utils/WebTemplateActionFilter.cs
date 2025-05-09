using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GC.WebTemplate.GCDS.Utils
{
    public class WebTemplateActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Set the default values for the model
            if (context.Controller is Controller controller)
            {
                var modelAccessor = (IWebTemplateModelAccessor)controller.HttpContext.RequestServices.GetService(typeof(IWebTemplateModelAccessor));
                var webTemplateModel = modelAccessor.Model;

                controller.ViewData["WebTemplateModel"] = webTemplateModel;
            }

            base.OnActionExecuting(context);
        }
    }
}
