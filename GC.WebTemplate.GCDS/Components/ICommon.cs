namespace GC.WebTemplate.GCDS.Components
{
    public interface ICommon
    {
        string Lang { get; set; }
        string? Slot { get; set; }
        string SkipToHref => "#main-content";
    }
}