using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace GCDS.NetTemplate.Core
{
    public class TemplateActionFilter(ITemplateRegister register) : ActionFilterAttribute
    {     
        // This is used to load the template for the MVC controller
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is Controller controller)
            {
                var cad = context.ActionDescriptor as ControllerActionDescriptor;
                var templateAtt = cad?.MethodInfo.GetCustomAttributes<TemplateTypeAttribute>()
                .Concat(cad.ControllerTypeInfo.GetCustomAttributes<TemplateTypeAttribute>());
                register.RegisterTemplate(controller.ViewData, controller.HttpContext,templateAtt);
            }

            base.OnActionExecuting(context);
        }
    }
}
