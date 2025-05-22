namespace GCDS.NetTemplate.Components
{
    public class Common : ICommon
    {
        /// <summary>
        /// A language indicator to toogle the 
        /// Always set by the CurrentUICulture by default
        /// </summary>
        public string Lang { get; set; } = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

        /// <summary>
        /// Used to indicate what "slot" the component is in for GCDS
        /// Generally set by the component calling it
        /// </summary>
        public string? Slot { get; set; }
    }
}
