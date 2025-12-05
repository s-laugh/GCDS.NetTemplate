using static GCDS.NetTemplate.Templates.TemplateBase;

namespace GCDS.NetTemplate.Components
{
    /// <summary>
    /// Class holder for the breadcrumb properties as defined in the GCDS template
    /// https://design-system.alpha.canada.ca/en/components/breadcrumbs/
    /// </summary>
    public class GcdsBreadcrumbs : CommonProps
    {
        /// <summary>
        /// Allows the user to remove the base route Canada.ca from the breadcrumbs
        /// </summary>
        public bool HideCanadaLink { get; set; } = false;

        /// <summary>
        /// List of links to be displayed in the breadcrumbs
        /// </summary>
        public IEnumerable<GcdsLink>? Items { get; set; }

        public ViewDataAction ItemsAction { get; set; } = ViewDataAction.Replace;
    }
}
