namespace GCDS.NetTemplate.Utils
{
    public static class HeadElementsExtentions
    {
        public static void AddScript(this List<HeadElement> headElements, string src, bool async = false, bool defer = false)
        {
            var attributes = new Dictionary<string, string> { { "src", src } };
            if (async) { attributes["async"] = async.ToString().ToLower(); }
            if (defer) { attributes["defer"] = defer.ToString().ToLower(); }

            headElements.Add(new HeadElement
            {
                TagName = "script",
                Attributes = attributes,
                InnerHtml = "" // not null so closing tag renders
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
