namespace GCDS.NetTemplate.Components
{
    public class TopNav : Common, IMenu
    {
        public required string Label { get; set; }

        public enum AlignmentType
        {
            right,
            center,
            left
        }
        public AlignmentType Alignment { get; set; } = AlignmentType.right;
        public Link? Home { get; set; }
        public List<INavLink> Links { get; set; } = new List<INavLink>(); 

    }
}
