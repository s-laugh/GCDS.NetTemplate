namespace GCDS.NetTemplate.Components.Gcds
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
        public GcdsLink? Home { get; set; }

        /// <summary>
        /// Links or NavGroups (dropdown of links) to be displayed in the TopNav
        /// </summary>
        public IEnumerable<ISlotHeaderNavLink> Links { get; set; } = new List<ISlotHeaderNavLink>();

        /// <summary>
        /// Enables the user to provide limited custom styling for the TopNav
        /// </summary>
        public string? StyleOverride { get; set; }
    }
}
