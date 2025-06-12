using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Core;

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
            template.Inizialize(
                new ExtSiteTitle { 
                    Text = "My Application",
                    Href = Url.Page("Index")
                },
                "Internal Page Name"
            );
        }
    }

}
