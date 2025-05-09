namespace GC.WebTemplate.GCDS.Components
{
    public class Common : ICommon
    {
        public string Lang { get; set; } = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
        public string? Slot { get; set; }
        public string SkipToHref => "#main-content";
    }
}
