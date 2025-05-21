using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Models;
using GCDS.NetTemplate.MVC.Sanity.Models;
using GCDS.NetTemplate.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            var template = ViewData[Constants.TEMPLATE_MODEL] as TemplateModel;
            template.Header.Breadcrumb = new Breadcrumbs { Items = [new Link { Text = "Home" }] };
            template.Header.Menu = new TopicMenu();

            template.Header.Search = new Search();

            template.Footer.Display = Footer.DisplayType.full;
            template.Footer.ContextualHeading = "My Application Footer";
            template.Footer.ContextualLinks = [
                new Link { Text = "Link 1", Href = "#" },
                new Link { Text = "Link 2", Href = "#" },
                new Link { Text = "Link 3", Href = "#" },
                new Link { Text = "Link 4", Href = "#" }
                ];
            template.Footer.SubLinks = [
                new Link { Text = "Link 1", Href = "#" },
                new Link { Text = "Link 2", Href = "#" },
                new Link { Text = "Link 3", Href = "#" },
                new Link { Text = "Link 4", Href = "#" }
                ];

            return View();
        }

        public IActionResult Internal()
        {
            var template = ViewData[Constants.TEMPLATE_MODEL] as TemplateModel;

           // template.TemplateSettings.LoadBootstrapCdn = true;
            template.Header.Breadcrumb = new Breadcrumbs { Items = [new Link { Text = "Home" }] };
            template.InternalAppHeader = new InternalAppHeader
            {
                SiteTitle = new Link
                {
                    Text = "My Application",
                    Href = Url.Action("Index")
                },
                StyleOverride = "border-bottom: 4px solid #243851"
            };
            template.Header.Menu = new TopNav
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
