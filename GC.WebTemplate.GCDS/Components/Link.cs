namespace GC.WebTemplate.GCDS.Components
{
    public class Link : Common, ILink
    {
        public string? Href { get; set; }
        public required string Text { get; set; }
    }
}
