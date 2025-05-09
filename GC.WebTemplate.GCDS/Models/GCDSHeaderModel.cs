namespace GC.WebTemplate.GCDS.Models
{
    public class GCDSHeaderModel
    {
        public bool SignatureHasLink { get; set; } = true;
        public string SignatureVariant { get; set; } = "colour";

        public string? Banner { get; set; }
        public string? Breadcrumb { get; set; }
        public string? Menu { get; set; }
        public string? Search { get; set; }
        public string? SkipToNav { get; set; }
        public string? LangToggle { get; set; }
    }
}
