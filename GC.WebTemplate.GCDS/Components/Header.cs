namespace GC.WebTemplate.GCDS.Components
{
    public class Header : Common
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

        public Breadcrumbs? Breadcrumb { get; set; }
        public IMenu? Menu { get; set; }
        public string? Search { get; set; }
        public string? SkipToNav { get; set; }
        public string? LangToggle { get; set; }
    }
}
