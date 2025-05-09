using System.Diagnostics;
using GC.WebTemplate.GCDS.Components;
using GC.WebTemplate.GCDS.Models;
using GC.WebTemplate.GCDS.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GC.WebTemplate.GCDS.Controllers
{

    [WebTemplateActionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var template = ViewData["WebTemplateModel"] as WebTemplateModel;
            template.Header.Breadcrumb = new Breadcrumbs { Items = [new Link { Text = "Home" }] };
            template.Header.Menu = new TopicMenu();

            template.Header.Menu = new TopNav
            {
                Label = "Top Nav",
                Home = new Link { Text = "Home", Href = "/" },
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
                ]
            };

            template.Header.Search = new Search();

            return View();
        }

    }
}
