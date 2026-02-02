namespace GCDS.NetTemplate.Components
{
    /// <summary>
    /// Class holder for the Side navigation properties as defined in the GCDS template'
    /// https://design-system.alpha.canada.ca/en/components/side-navigation/
    /// </summary>
    public class GcdsSideNav : CommonProps, ISlotSideNav
    {
        /// <summary>
        /// Accessability information
        /// </summary>
        public required string Label { get; set; }

        /// <summary>
        /// Links or NavGroups (dropdown of links) to be displayed in the TopNav
        /// </summary>
        public IEnumerable<ISlotNavLink> Links { get; set; } = [];

        /// <summary>
        /// Enables the user to provide limited custom styling for the TopNav
        /// </summary>
        public string? StyleOverride { get; set; }
    }
}
