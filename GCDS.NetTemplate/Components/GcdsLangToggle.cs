namespace GCDS.NetTemplate.Components
{
    /// <summary>
    /// Implements GCDS Language toogle component.
    /// Not used by default in templates, but avaliable as a required component for custom implementations ease of use.
    /// https://design-system.alpha.canada.ca/en/components/language-toggle/
    /// </summary>
    public class GcdsLangToggle : CommonProps
    {
        /// <summary>
        /// Link to tigger the language switch
        /// </summary>
        public required string Href { get; set; }

        /// <summary>
        /// Override default styles of the componet
        /// </summary>
        public string? StyleOverride { get; set; }
    }
}
