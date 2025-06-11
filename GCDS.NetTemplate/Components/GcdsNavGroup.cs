namespace GCDS.NetTemplate.Components
{
    /// <summary>
    /// Class holder for the NavGroup properties within the TopNav component in GCDS
    /// </summary>
    public class GcdsNavGroup : ISlotHeaderNavLink
    {
        /// <summary>
        /// This is the header, clickable text for the group to open
        /// </summary>
        public required string Label { get; set; }

        /// <summary>
        /// links that will be shown under the header
        /// </summary>
        public required IEnumerable<GcdsLink> Links { get; set; }
    }
}
