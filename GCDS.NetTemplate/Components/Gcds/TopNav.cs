namespace GCDS.NetTemplate.Components.Gcds
{
    /// <summary>
    /// Class holder for the Top navigation properties as defined in the GCDS template
    /// https://design-system.alpha.canada.ca/en/components/top-navigation/
    /// </summary>
    public class TopNav : Common, IMenu
    {
        public enum AlignmentType
        {
            right,
            center,
            left
        }

        /// <summary>
        /// Accessability information
        /// </summary>
        public required string Label { get; set; }

        /// <summary>
        /// Changes the orientation of the Links
        /// </summary>
        public AlignmentType Alignment { get; set; } = AlignmentType.right;

        /// <summary>
        /// Customize the content for the home link.
        /// </summary>
        public Link? Home { get; set; }

        /// <summary>
        /// Links to be displayed in the TopNav
        /// </summary>
        public IEnumerable<INavLink> Links { get; set; } = new List<INavLink>();

        /// <summary>
        /// Enables the user to provide limited custom styling for the TopNav
        /// </summary>
        public string? StyleOverride { get; set; }
    }
}
