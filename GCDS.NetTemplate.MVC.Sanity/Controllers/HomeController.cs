using GCDS.NetTemplate.MVC.Sanity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GCDS.NetTemplate.Templates;
using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Core;
using Microsoft.AspNetCore.Html;

namespace GCDS.NetTemplate.MVC.Sanity.Controllers
{
    //[ServiceFilter(typeof(TemplateActionFilter))] // Uncomment to use the TemplateActionFilter when not enabled globally
    public class HomeController : Controller
    {
        [TemplateType(typeof(Splash))]
        public IActionResult Index()
        {
            HttpContext.SetTemplateCulture(CommonConstants.ENGLISH_CULTURE);

            var template = ViewData.GetTemplate<Splash>();
            ArgumentNullException.ThrowIfNull(template);
            template.LanguageSelector = new ExtLanguageSelector("Custom Splash Title", "Titre d'claboussure personnalis", Url.Action("Home")!);
            template.PageTitle = "Custom Title / Titre personnalis";
            template.HeadElements.AddMeta("description", "This is a custom splash page for testing purposes.");
            return View();
        }

        public IActionResult Home()
        {
            var template = ViewData.GetTemplate<Basic>();
            ArgumentNullException.ThrowIfNull(template);
            template.PageTitle = "Home Page";
            template.Header.Banner = new CustomPartial() { ViewName = "Banner", Model = new Banner() { Text = "Jokes on You!" } };
            template.Header.SkipToNav = new ExtSkipTo() { Link = new GcdsLink { Text = new HtmlString("Skip to nav content"), Href = "#nav" } };

            template.Header.Menu = new GcdsTopNav
            {
                Label = "Top Nav",
                Alignment = GcdsTopNav.AlignmentType.left,
                Links =
               [
                   new GcdsNavLink { Text = new HtmlString("Link 1"), Href = "#" },
                    new GcdsNavGroup { Label = "Group 1",
                        Links =
                        [
                            new GcdsNavLink("#", "Link 1.1"),
                            new GcdsNavLink("#", "Link 1.2")
                        ]
                    },
                    new GcdsNavLink ("#", "Link 2")
               ],
                //StyleOverride = "background-color: #e1e4e7;"
            };

            template.Header.Breadcrumb = new GcdsBreadcrumbs
            {
                Items = [new GcdsLink("#", "Home")]
            };

            return View();
        }

        public IActionResult SideNav()
        {
            var template = ViewData.GetTemplate<Basic>();
            ArgumentNullException.ThrowIfNull(template);
            template.Initialize("Side Nav Page");
            template.SideNav = new GcdsSideNav
            {
                Label = "Left Nav",
                Links = LargeMenu,
                StyleOverride = "background-color: #e1e4e7;"
            };

            return View();
        }

        [TemplateType(typeof(InternalApp))]
        public IActionResult AltInternal()
        {
            var template = ViewData.GetTemplate<InternalApp>();
            ArgumentNullException.ThrowIfNull(template);
            template.Initialize("Alt Internal Page", new ExtSiteTitle { Text = "Home", Href = "#" });

            template.Header!.Menu = new CustomPartial()
            {
                ViewName = "CustomNav",
                Model = new Banner { Text = "This is my custom menu" }
            };

            return View("Internal");
        }

        [TemplateType(typeof(InternalApp))]
        public IActionResult Internal()
        {
            var template = ViewData.GetTemplate<InternalApp>();
            ArgumentNullException.ThrowIfNull(template);
            template.PageTitle = "Home Page";
            template.Initialize("Internal Page", "My Application Title");
            // OR
            template.Initialize("Internal Page", new ExtSiteTitle { Text = "Home", Href = "#" })
                .HeadElements.AddMeta("name", "content");

            // OR
            template.Header = new ExtAppHeader
            {
                Banner = new CustomPartial() { ViewName = "Banner", Model = new Banner() { Text = "Jokes on You!" } },
                AppHeaderTop = new ExtAppHeaderTop
                {
                    LanguageToggle = new GcdsLangToggle { Href = template.LangToggleHref },
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
                    Links = LargeMenu // only one layer of groups supported in top nav
                    //StyleOverride = "background-color: #e1e4e7;"
                },
                Breadcrumbs = new GcdsBreadcrumbs
                {
                    Items = [
                        new GcdsLink
                        {
                            Text = new HtmlString("Home"),
                            Href = Url.Action("Index") ?? ""
                        },
                        ]
                }
            };

            template.PageTitleAction = TemplateBase.ViewDataAction.Append;
            template.Header.Breadcrumbs.ItemsAction = TemplateBase.ViewDataAction.Prepend;
            //template.Footer.StyleOverride = "border-top: 4px solid #243851; background: #f8f8f8;";

            return View();
        }

        [TemplateType(typeof(InternalApp))]
        public IActionResult InternalSideNav(bool variant = false)
        {
            var template = ViewData.GetTemplate<InternalApp>();
            ArgumentNullException.ThrowIfNull(template);
            template.Initialize("Internal Left Nav Page", "My Application Title");
            template.SideNav = new GcdsSideNav
            {
                Label = "Left Nav",
                Links = LargeMenu,
                StyleOverride = "background-color: #e1e4e7;"
            };

            return View(variant ? "SideNavVariant" : "SideNav");
        }

        [TemplateType(typeof(InternalApp))]
        public IActionResult AltInternalSideNav()
        {
            var template = ViewData.GetTemplate<InternalApp>();
            ArgumentNullException.ThrowIfNull(template);
            template.Initialize("Internal Left Nav Page", "My Application Title");
            template.SideNav = new CustomPartial()
            {
                ViewName = "CustomNav",
                Model = new Banner { Text = "This is my custom menu" }
            };
            ViewBag.SideNavWidth = "40%"; // Example of setting a custom width for the side nav; accepted as text, so px, %, etc. are all valid

            return View("SideNav");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static IEnumerable<ISlotNavLink> LargeMenu => [
            new GcdsNavLink { Text = new HtmlString("Link 1"), Href = "#" },
            new GcdsNavGroup { Label = "Group 1",
                Links =
                [
                    new GcdsNavLink("#", "Link 2.1"),
                    new GcdsNavLink("#", "Link 2.2"),
                    new GcdsNavGroup { Label = "Group 2",
                        Links =
                        [
                            new GcdsNavLink("#", "Link 1.3.1"),
                            new GcdsNavLink("#", "Link 1.3.2"),
                            new GcdsNavGroup { Label = "Group 3",
                                Links =
                                [
                                    new GcdsNavLink("#", "Link 1.3.3.1"),
                                    new GcdsNavLink("#", "Link 1.3.3.2")
                                ]
                            },
                        ]
                    },
                ]
            },
            new GcdsNavLink("#", "Link 4"),
            new GcdsNavLink("#", "Link 5"),
            new GcdsNavLink("#", "Link 6"),
            new GcdsNavLink("#", "Link 7"),
            new GcdsNavLink("#", "Link 8"),
            new GcdsNavGroup
            {
                Label = "Group 4",
                Links =
                [
                    new GcdsNavLink("#", "Link 9.1"),
                    new GcdsNavLink("#", "Link 9.2"),
                    new GcdsNavLink("#", "Link 9.3"),
                    new GcdsNavLink("#", "Link 9.4"),
                    new GcdsNavLink("#", "Link 9.5"),
                    new GcdsNavLink("#", "Link 9.6"),
                    new GcdsNavLink("#", "Link 9.7"),
                    new GcdsNavLink("#", "Link 9.8")
                ]
            },
            new GcdsNavLink("#", "Link 10"),
            new GcdsNavLink("#", "Link 11"),
            new GcdsNavLink("#", "Link 12"),
            new GcdsNavLink("#", "Link 13")
        ];
    }
}
