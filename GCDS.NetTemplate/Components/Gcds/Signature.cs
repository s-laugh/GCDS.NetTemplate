namespace GCDS.NetTemplate.Components.Gcds
{
    /// <summary>
    /// Implements GCDS Signature component.
    /// Not used by default in templates, but avaliable as a required component for custom implementations ease of use.
    /// https://design-system.alpha.canada.ca/en/components/signature/
    /// </summary>
    public class Signature : Common
    {
        public enum SignatureType
        {
            wordmark,
            signature
        }
        public enum VariantType
        {
            color,
            white
        }

        /// <summary>
        /// toogle the signature to link to the Canada.ca homepage
        /// </summary>
        public bool HasLink { get; set; }

        /// <summary>
        /// Type of signature to use
        /// </summary>
        public SignatureType Type { get; set; } = SignatureType.signature;

        /// <summary>
        /// The color of the signature
        /// </summary>
        public VariantType Variant { get; set; } = VariantType.color;

    }
}
