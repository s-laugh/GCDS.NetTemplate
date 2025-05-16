namespace GCDS.NetTemplate.Components
{
    public class Link : Common, ILink, INavLink
    {
        public string? Href { get; set; }
        public required string Text { get; set; }

        public enum DisplayType
        {
            inline,
            block,
        }
        public DisplayType Display { get; set; } = DisplayType.inline;
        public string? Download { get; set; }
        public bool External { get; set; }
        public string? Rel { get; set; }
        public enum SizeType
        {
            inherit,
            regular,
            small
        }
        public SizeType Size { get; set; } = SizeType.inherit;
        public string Target { get; set; } = "_self";
        public string? Type { get; set; }
        public enum VariantType
        {
            @default,
            light,
        }
        public VariantType Variant { get; set; } = VariantType.@default;
    }
}
