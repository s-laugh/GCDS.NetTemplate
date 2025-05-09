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
            template.Header.Breadcrumb = new GCDSBreadcrumbs { Breadcrumbs = [new GCDSBreadcrumbsItem { Text = "Home"}] };

            return View();
        }

    }
}
