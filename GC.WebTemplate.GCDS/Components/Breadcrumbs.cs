namespace GC.WebTemplate.GCDS.Components
{
    public class Breadcrumbs : Common
    {
        public bool HideCanadaLink { get; set; } = false;
        public List<Link>? Items { get; set; }
    }
}
