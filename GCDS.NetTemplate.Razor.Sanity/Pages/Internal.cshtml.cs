using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GCDS.NetTemplate.Utils;
using Microsoft.AspNetCore.Mvc;
using GCDS.NetTemplate.Components;

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
            template.Header = new ExtAppHeader(
                new ExtSiteTitle { 
                    Text = "My Application",
                    Href = Url.Page("Index")
                }
            );
        }
    }

}
