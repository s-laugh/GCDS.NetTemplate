using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace GCDS.NetTemplate.Core
{
    // for MVC
    public class TemplateActionFilter(IInitializer initializer) : ActionFilterAttribute
    {     
        // This is used to load the template for the MVC controller
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is Controller controller)
            {
                var cad = context.ActionDescriptor as ControllerActionDescriptor;
                var templateAtt = cad?.MethodInfo.GetCustomAttributes<TemplateTypeAttribute>()
                .Concat(cad.ControllerTypeInfo.GetCustomAttributes<TemplateTypeAttribute>());
                initializer.InitializeTemplate(controller.ViewData, controller.HttpContext,templateAtt);
            }

            base.OnActionExecuting(context);
        }
    }

    // for Razor
    public class TemplatePageFilter(IInitializer initializer) : IAsyncPageFilter
    {
        // This is here to fufill the IAsyncPageFilter interface contract
        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context) => Task.CompletedTask;

        // This is used to load the template for the Razor page
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            if (context.HandlerInstance is PageModel pageModel)
            {
                var templateAttr = pageModel.GetType().GetCustomAttributes<TemplateTypeAttribute>();
                initializer.InitializeTemplate(pageModel.ViewData, pageModel.HttpContext, templateAttr);
            }

            await next();
        }
    }
}
