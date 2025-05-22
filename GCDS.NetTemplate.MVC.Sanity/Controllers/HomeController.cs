using GCDS.NetTemplate.Components.Gcds;
using GCDS.NetTemplate.Components.Custom;
using GCDS.NetTemplate.MVC.Sanity.Models;
using GCDS.NetTemplate.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GCDS.NetTemplate.Templates.Custom;
using GCDS.NetTemplate.Templates;

namespace GCDS.NetTemplate.MVC.Sanity.Controllers
{
    [TemplateActionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [TemplateType(typeof(InternalAppTemplate))]
        public IActionResult Internal()
        {
            var template = ViewData[Constants.TEMPLATE_DATA] as InternalAppTemplate;

            // template.TemplateSettings.LoadBootstrapCdn = true;
            //emplate.Header.Breadcrumb = new Breadcrumbs { Items = [new Link { Text = "Home" }] };
            template.Header = new InternalAppHeader
            {
                SiteTitle = new Link
                {
                    Text = "My Application",
                    Href = Url.Action("Index")
                },
                StyleOverride = "border-bottom: 4px solid #243851",
                Menu = new TopNav
                {
                    Label = "Top Nav",
                    Alignment = TopNav.AlignmentType.left,
                    Links =
               [
                   new Link { Text = "Link 1", Href = "#" },
                    new NavGroup { Label = "Group 1",
                        Links =
                        [
                            new Link { Text = "Link 1.1", Href = "#" },
                            new Link { Text = "Link 1.2", Href = "#" }
                        ]
                    },
                    new Link { Text = "Link 2", Href = "#" }
               ],
                    StyleOverride = "background-color: #e1e4e7;"
                }
            };
            template.Footer.StyleOverride = "border-top: 4px solid #243851; background: #f8f8f8;";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
