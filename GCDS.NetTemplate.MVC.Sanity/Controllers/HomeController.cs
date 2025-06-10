using GCDS.NetTemplate.MVC.Sanity.Models;
using GCDS.NetTemplate.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GCDS.NetTemplate.Templates;
using GCDS.NetTemplate.Components;

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

        [TemplateType(typeof(Splash))]
        public IActionResult Index()
        {
            HttpContext.SetTemplateCulture(Constants.ENGLISH_CULTURE);

            var template = ViewData.GetTemplate<Splash>();
            template.LanguageSelector = new ExtLanguageSelector("Custom Splash Title", "Titre d'éclaboussure personnalisé", Url.Action("Home"));
            template.PageTitle = "Custom Title / Titre personnalisé";
            template.HeadElements.AddMeta("description", "This is a custom splash page for testing purposes.");
            return View(); 
        }

        public IActionResult Home()
        {
            var template = ViewData.GetTemplate<Basic>();
            template.Header.Banner = new CustomPartial() { ViewName = "Banner", Model = new Banner() { Text = "Jokes on You!" } };
            template.Header.SkipToNav = new ExtSkipTo() { Link = new GcdsLink { Text = "Skip to nav content", Href = "#nav" } };

            template.Header.Menu = new GcdsTopNav
            {
                Label = "Top Nav",
                Alignment = GcdsTopNav.AlignmentType.left,
                Links =
               [
                   new GcdsLink { Text = "Link 1", Href = "#" },
                    new GcdsNavGroup { Label = "Group 1",
                        Links =
                        [
                            new GcdsLink { Text = "Link 1.1", Href = "#" },
                            new GcdsLink { Text = "Link 1.2", Href = "#" }
                        ]
                    },
                    new GcdsLink { Text = "Link 2", Href = "#" }
               ],
                //StyleOverride = "background-color: #e1e4e7;"
            };

            template.Header.Breadcrumb = new GcdsBreadcrumbs
            {
                Items = [
                        new GcdsLink
                        {
                            Text = "Home"
                        }
                        ]
            };

            return View();
        }

        [TemplateType(typeof(InternalApp))]
        public IActionResult Internal()
        {
            var template = ViewData.GetTemplate<InternalApp>();

            template.Header = new ExtAppHeader("My Application");
            template.Header = new ExtAppHeader(new ExtSiteTitle { Text = "Home", Href = "#" });
            // OR
            template.Header = new ExtAppHeader
            {
                AppHeaderTop = new ExtAppHeaderTop
                {
                    SiteTitle = new ExtSiteTitle
                    {
                        Text = "My Very Long Application Title That fills the whole header",
                        Href = Url.Action("Index")
                    },
                    StyleOverride = "border-bottom: 4px solid #243851"
                },
                Menu = new GcdsTopNav
                {
                    Label = "Top Nav",
                    Alignment = GcdsTopNav.AlignmentType.left,
                    Links =
               [
                   new GcdsLink { Text = "Link 1", Href = "#" },
                    new GcdsNavGroup { Label = "Group 1",
                        Links =
                        [
                            new GcdsLink { Text = "Link 1.1", Href = "#" },
                            new GcdsLink { Text = "Link 1.2", Href = "#" }
                        ]
                    },
                    new GcdsLink { Text = "Link 2", Href = "#" }
               ],
                    //StyleOverride = "background-color: #e1e4e7;"
                },
                Breadcrumbs = new GcdsBreadcrumbs
                {
                    Items = [
                        new GcdsLink
                        {
                            Text = "Home",
                            Href = Url.Action("Index")
                        },
                        ]
                }
            };
            //template.Footer.StyleOverride = "border-top: 4px solid #243851; background: #f8f8f8;";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
