namespace GCDS.NetTemplate.Components.Gcds
{
    public class NavGroup : INavLink
    {
        public required string Label { get; set; }
        public required IEnumerable<ILink> Links { get; set; }
    }
}
