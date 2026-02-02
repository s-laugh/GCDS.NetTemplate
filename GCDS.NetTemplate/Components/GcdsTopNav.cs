namespace GCDS.NetTemplate.Components
{
    /// <summary>
    /// Class holder for the Top navigation properties as defined in the GCDS template
    /// https://design-system.alpha.canada.ca/en/components/top-navigation/
    /// </summary>
    public class GcdsTopNav : CommonProps, ISlotHeaderMenu
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
        public GcdsNavLink? Home { get; set; }

        /// <summary>
        /// Links or NavGroups (dropdown of links) to be displayed in the TopNav
        /// </summary>
        public IEnumerable<ISlotNavLink> Links { get; set; } = new List<ISlotNavLink>();

        /// <summary>
        /// Enables the user to provide limited custom styling for the TopNav
        /// </summary>
        public string? StyleOverride { get; set; }
    }
}
