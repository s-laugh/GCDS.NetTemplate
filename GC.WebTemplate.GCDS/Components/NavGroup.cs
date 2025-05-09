namespace GC.WebTemplate.GCDS.Components
{
    public class NavGroup : ILink
    {
        public required string Label { get; set; }
        public required List<Link> Links { get; set; }
    }
}
