namespace GCDS.NetTemplate.Utils
{
    public class HeadElement
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

    public static class ListHeadElementExtentions
    {
        public static void AddScript(this List<HeadElement> headElements, string src, bool async = false, bool defer = false)
        {
            headElements.Add(new HeadElement
            {
                TagName = "script",
                Attributes = new Dictionary<string, string>
                {
                    { "src", src },
                    { "async", async.ToString().ToLower() },
                    { "defer", defer.ToString().ToLower() }
                },
                InnerHtml = ""
            });
        }
        public static void AddLink(this List<HeadElement> headElements, string href, string rel = "stylesheet")
        {
            headElements.Add(new HeadElement
            {
                TagName = "link",
                Attributes = new Dictionary<string, string>
                {
                    { "href", href },
                    { "rel", rel }
                }
            });
        }
        public static void AddStyle(this List<HeadElement> headElements, string cssContent)
        {
            headElements.Add(new HeadElement
            {
                TagName = "style",
                InnerHtml = cssContent
            });
        }
        public static void AddMeta(this List<HeadElement> headElements, string name, string content, string? title = null)
        {
            var attributes = new Dictionary<string, string>
            {
                { "name", name },
                { "content", content }
            };

            if (!string.IsNullOrEmpty(title))
            {
                attributes["title"] = title;
            }

            headElements.Add(new HeadElement
            {
                TagName = "meta",
                Attributes = attributes
            });
        }
        /// <summary>
        /// Simplifying the creation of a head element
        /// </summary>
        /// <param name="headElements">target property to store the element</param>
        /// <param name="tagName">name of the element tag</param>
        /// <param name="attributes">any attributes the element needs</param>
        /// <param name="innerHtml">html that sits within the element, ensure it's not null to have a separated closing tag (required for scripts)</param>
        public static void AddCustom(this List<HeadElement> headElements, string tagName, Dictionary<string, string> attributes, string? innerHtml = null)
        {
            headElements.Add(new HeadElement
            {
                TagName = tagName,
                Attributes = attributes,
                InnerHtml = innerHtml
            });
        }
        public static string Render(this List<HeadElement> headElements)
        {
            return string.Join(Environment.NewLine, headElements.Select(he => he.Render()));
        }
    }
}
