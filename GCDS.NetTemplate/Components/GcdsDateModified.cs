namespace GCDS.NetTemplate.Components
{
    /// <summary>
    /// Implements GCDS Date modified component.
    /// Not used by default in templates, but avaliable as a required component for custom implementations ease of use.
    /// https://design-system.alpha.canada.ca/en/components/date-modified/
    /// </summary>
    public class GcdsDateModified : CommonProps
    {
        public enum DateModifiedType
        {
            date,
            version
        }

        /// <summary>
        /// The date or version text to display in the component.
        /// </summary>
        public required string Text { get; set; }

        /// <summary>
        /// Switch to Version type.
        /// </summary>
        public DateModifiedType Type { get; set; } = DateModifiedType.date;
    }
}
