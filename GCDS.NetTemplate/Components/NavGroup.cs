namespace GCDS.NetTemplate.Components
{
    public class NavGroup : INavLink
    {
        public required string Label { get; set; }
        public required List<ILink> Links { get; set; }
    }
}
