namespace GCDS.NetTemplate.Components
{
    public class Search : Common
    {
        public string Action { get; set; } = "/sr/srb.html";
        public string Method { get; set; } = "get";
        public string Name { get; set; } = "q";
        public string Placeholder { get; set; } = "Canada.ca";
        public string SearchId { get; set; } = "search";
    }
}
