using GCDS.NetTemplate.Components.Gcds;
using GCDS.NetTemplate.Components.Custom;
using GCDS.NetTemplate.MVC.Sanity.Models;
using GCDS.NetTemplate.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GCDS.NetTemplate.Templates.Custom;
using GCDS.NetTemplate.Templates;
using GCDS.NetTemplate.Templates.Gcds;

namespace GCDS.NetTemplate.MVC.Sanity.Controllers
{
    // [ServiceFilter(typeof(TemplateActionFilter))] // Uncomment to use the TemplateActionFilter when not enabled globably
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var template = ViewData.GetTemplate<BasicTemplate>();
            template.Header.Banner = new CustomPartial() { ViewName = "Banner", Model = new Banner() { Text = "Jokes on You!" } };
            template.Header.SkipToNav = new SkipTo() { Link = new Link { Text = "Skip to nav content", Href = "#nav" } };

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
                //StyleOverride = "background-color: #e1e4e7;"
            };

            template.Header.Breadcrumb = new Breadcrumbs
            {
                Items = [
                        new Link
                        {
                            Text = "Home"
                        }
                        ]
            };

            return View();
        }

        [TemplateType(typeof(InternalAppTemplate))]
        public IActionResult Internal()
        {
            var template = ViewData.GetTemplate<InternalAppTemplate>();

            template.Header = new InternalAppHeader("My Application");
            template.Header = new InternalAppHeader(new Link { Text = "Home", Href = "#" });
            // OR
            template.Header = new InternalAppHeader
            {
                AppHeaderTop = new AppHeaderTop
                {
                    SiteTitle = new Link
                    {
                        Text = "My Application",
                        Href = Url.Action("Index")
                    },
                    StyleOverride = "border-bottom: 4px solid #243851"
                },
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
                    //StyleOverride = "background-color: #e1e4e7;"
                },
                Breadcrumbs = new Breadcrumbs
                {
                    Items = [
                        new Link
                        {
                            Text = "Home",
                            Href = Url.Action("Index")
                        },
                        ]
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
