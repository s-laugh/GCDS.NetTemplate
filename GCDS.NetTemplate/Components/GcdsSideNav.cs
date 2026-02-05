namespace GCDS.NetTemplate.Components
{
    /// <summary>
    /// Class holder for the Side navigation properties as defined in the GCDS template'
    /// https://design-system.alpha.canada.ca/en/components/side-navigation/
    /// </summary>
    public class GcdsSideNav : CommonProps, ISlotSideNav
    {
        /// <summary>
        /// Accessibility information
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

        /// <summary>
        /// Allows toggling the scroll behavior of the SideNav.
        /// Defaults to true, meaning the SideNav will scroll if the content exceeds the height of the viewport.
        /// </summary>
        public bool Scroll { get; set; } = true;
    }
}
