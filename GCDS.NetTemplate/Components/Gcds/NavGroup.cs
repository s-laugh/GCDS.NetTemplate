namespace GCDS.NetTemplate.Components.Gcds
{
    /// <summary>
    /// Class holder for the NavGroup properties within the TopNav component in GCDS
    /// </summary>
    public class NavGroup : INavLink
    {
        /// <summary>
        /// This is the header, clickable text for the group to open
        /// </summary>
        public required string Label { get; set; }

        /// <summary>
        /// links that will be shown under the header
        /// </summary>
        public required IEnumerable<Link> Links { get; set; }
    }
}
