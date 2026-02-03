using GCDS.NetTemplate.Components;
using GCDS.NetTemplate.Core;
using GCDS.NetTemplate.Templates;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GCDS.NetTemplate.Razor.Sanity.Pages
{
    [TemplateType(typeof(InternalApp))]
    public class InternalSideNavModel : PageModel
    {
        public void OnGet()
        {
            var template = ViewData.GetTemplate<InternalApp>();
            ArgumentNullException.ThrowIfNull(template);
            template.Initialize("Internal Side Nav", "Razor Example");
            template.SideNav = new GcdsSideNav
            {
                Label = "Left Nav",
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
                StyleOverride = "background-color: #e1e4e7;"
            };
        }
    }
}
