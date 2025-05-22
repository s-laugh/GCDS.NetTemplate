namespace GCDS.NetTemplate.Components.Gcds
{
    /// <summary>
    /// Class holder for the Theme and topic menu properties as defined in the GCDS template
    /// https://design-system.alpha.canada.ca/en/components/theme-and-topic-menu/
    /// </summary>
    public class TopicMenu : Common, IMenu
    {
        /// <summary>
        /// Toggles the background and text of the menu color
        /// </summary>
        public bool Home { get; set; }
    }
}
