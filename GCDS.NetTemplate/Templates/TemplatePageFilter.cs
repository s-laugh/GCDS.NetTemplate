using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace GCDS.NetTemplate.Templates
{
    public class TemplatePageFilter(ITemplateAccessor accessor) : IAsyncPageFilter
    {
        // This is here to fufill the IAsyncPageFilter interface contract
        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context) => Task.CompletedTask;

        // This is used to load the template for the Razor page
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            if (context.HandlerInstance is PageModel pageModel)
            {
                var templateAttr = pageModel.GetType().GetCustomAttributes<TemplateTypeAttribute>();
                accessor.SetTemplate(pageModel.ViewData, pageModel.HttpContext, templateAttr);
            }

            await next();
        }
    }
}
