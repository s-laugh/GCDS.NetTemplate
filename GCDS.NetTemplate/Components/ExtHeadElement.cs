namespace GCDS.NetTemplate.Components
{
    public class ExtHeadElement
    {
        public required string TagName { get; set; } // e.g., "script", "link", "style"
        public Dictionary<string, string> Attributes { get; set; } = [];
        public string? InnerHtml { get; set; } // For inline scripts or styles

        public string Render()
        {
            var attrs = string.Join(" ", Attributes.Select(kv => $"{kv.Key}=\"{kv.Value}\""));
            if (InnerHtml == null)
                return $"<{TagName} {attrs} />";
            return $"<{TagName} {attrs}>{InnerHtml}</{TagName}>";
        }
    }
}
