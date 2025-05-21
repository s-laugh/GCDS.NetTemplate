using System.Text.Json;

namespace GCDS.NetTemplate.Components
{
    public interface ILink
    {
        string? Href { get; set; }
        string Text { get; set; }
    }

    public static class ListLinkExtensions
    {
        public static string ToJson(this IEnumerable<ILink> links)
        {
            var tranformedLinks = links.ToDictionary(link => link.Text, link => link.Href);
            var json = JsonSerializer.Serialize(tranformedLinks);
            return json;
        }
    }
}
