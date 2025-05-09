namespace GC.WebTemplate.GCDS.Components
{
    public class GCDSHeader : GCDSCommon
    {
        //TODO Implement language toggle
        public string LangHref { get; set; } = "#";
        public bool SignatureHasLink { get; set; } = true;
        public enum SignatureVariantType
        {
            colour,
            white
        }
        public SignatureVariantType SignatureVariant { get; set; } = SignatureVariantType.colour;

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        public string? Banner { get; set; }

        public GCDSBreadcrumbs? Breadcrumb { get; set; }
        public string? Menu { get; set; }
        public string? Search { get; set; }
        public string? SkipToNav { get; set; }
        public string? LangToggle { get; set; }
    }
}
