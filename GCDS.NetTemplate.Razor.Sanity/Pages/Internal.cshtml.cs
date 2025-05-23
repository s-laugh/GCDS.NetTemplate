using GCDS.NetTemplate.Templates.Custom;
using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GCDS.NetTemplate.Utils;
using GCDS.NetTemplate.Components.Custom;
using Microsoft.AspNetCore.Mvc;
using GCDS.NetTemplate.Components.Gcds;

namespace GCDS.NetTemplate.Razor.Sanity.Pages
{

    [TemplateType(typeof(InternalAppTemplate))]
    public class InternalModel : PageModel
    {
        private readonly ILogger<InternalModel> _logger;

        public InternalModel(ILogger<InternalModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var template = ViewData.GetTemplate<InternalAppTemplate>();
            template.Header = new InternalAppHeader()
            {
                SiteTitle = new Link()
                {
                    Text = "My Application",
                    Href = Url.Page("Index")
                },
            };
        }
    }

}
