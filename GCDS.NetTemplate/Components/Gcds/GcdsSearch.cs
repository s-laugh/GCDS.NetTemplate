namespace GCDS.NetTemplate.Components.Gcds
{
    /// <summary>
    /// Class holder for the search properties as defined in the GCDS template
    /// https://design-system.alpha.canada.ca/en/components/search/
    /// </summary>
    public class GcdsSearch : CommonProps
    {
        public string Action { get; set; } = "/sr/srb.html";
        public string Method { get; set; } = "get";
        public string Name { get; set; } = "q";
        public string Placeholder { get; set; } = "Canada.ca";
        public string SearchId { get; set; } = "search";
    }
}
