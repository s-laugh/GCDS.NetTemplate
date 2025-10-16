using System.Diagnostics.CodeAnalysis;

namespace GCDS.NetTemplate.Components
{
    /// <summary>
    /// Class holder for the link properties as defined in the GCDS template
    /// https://design-system.alpha.canada.ca/en/components/link/
    /// </summary>
    public class GcdsLink : CommonLinkBase
    {
        public GcdsLink() { }

        [SetsRequiredMembers]
        public GcdsLink(string href, string text) : base(href, text) { }

        public enum DisplayType
        {
            inline,
            block,
        }
        public enum SizeType
        {
            inherit,
            regular,
            small
        }
        public enum VariantType
        {
            @default,
            light,
        }

        public DisplayType Display { get; set; } = DisplayType.inline;
        public string? Download { get; set; }
        public bool External { get; set; }
        public string? Rel { get; set; }
        public SizeType Size { get; set; } = SizeType.inherit;
        public string Target { get; set; } = "_self";
        public string? Type { get; set; }
        public VariantType Variant { get; set; } = VariantType.@default;
    }
}
