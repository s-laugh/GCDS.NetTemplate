using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Core;
using Microsoft.AspNetCore.Html;

namespace GCDS.NetTemplate.Razor.Sanity.Pages
{

    [TemplateType(typeof(InternalApp))]
    public class InternalModel : PageModel
    {
        private readonly ILogger<InternalModel> _logger;

        public InternalModel(ILogger<InternalModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var template = ViewData.GetTemplate<InternalApp>();            
            ArgumentNullException.ThrowIfNull(template);
            template.Inizialize("Internal",
                new ExtSiteTitle
                {
                    Text = "My Application",
                    Href = Url.Page("Index")
                }
            );
            
            ArgumentNullException.ThrowIfNull(template.Header);
            template.Header.Breadcrumbs = new GcdsBreadcrumbs
            {
                Items = [
                    new GcdsLink
                    {
                        Text = new HtmlString("Home <abbr title=\"Page\">Pg.</abbr>"),
                        Href = Url.Action("Index") ?? ""
                    },
                ]
            };
        }
    }

}
