namespace GC.WebTemplate.GCDS.Components
{
    public class GCDSBreadcrumbs : GCDSCommon
    {
        public string? Slot { get; set; }
        public bool HideCanadaLink { get; set; } = false;
        public List<GCDSBreadcrumbsItem>? Breadcrumbs { get; set; }
    }
}
