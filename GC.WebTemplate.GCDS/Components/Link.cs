using System.Text.Json;

namespace GC.WebTemplate.GCDS.Components
{
    public class Link : Common, ILink
    {
        public string? Href { get; set; }
        public required string Text { get; set; }
    }

    public static class ListLinkExtensions
    {
        public static string ToJson(this IEnumerable<Link> links)
        {
            var tranformedLinks = links.ToDictionary(link => link.Text, link => link.Href);
            var json = JsonSerializer.Serialize(tranformedLinks);
            return json;
        }
    }
}
