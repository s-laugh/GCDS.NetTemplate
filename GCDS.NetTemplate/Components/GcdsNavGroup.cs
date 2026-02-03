namespace GCDS.NetTemplate.Components
{
    /// <summary>
    /// Class holder for the NavGroup properties within the TopNav component in GCDS
    /// </summary>
    public class GcdsNavGroup : ISlotNavLink
    {
        /// <summary>
        /// Label for the nav group menu
        /// </summary>
        public required string Label { get; set; }

        private string? openTrigger;
        /// <summary>
        /// Label for the collapsed button trigger.
        /// Defaults to Label
        /// </summary>
        public string OpenTrigger
        {
            get => openTrigger ?? Label;
            set { openTrigger = value; }
        }

        /// <summary>
        /// Label for the expanded button trigger
        /// </summary>
        public string? CloseTrigger { get; set; }

        /// <summary>
        /// Has the nav group been expanded
        /// </summary>
        public bool Open { get; set; }

        /// <summary>
        /// links that will be shown under the header
        /// </summary>
        public required IEnumerable<GcdsNavLink> Links { get; set; }
    }
}
