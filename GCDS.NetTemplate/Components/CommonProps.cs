namespace GCDS.NetTemplate.Components
{
    /// <summary>
    /// Enables other interfaces to require the use of Common properties
    /// </summary>
    public interface ICommon
    {
        string Lang { get; set; }
        string? Slot { get; set; }
    }

    public class CommonProps : ICommon
    {
        private string? lang;
        /// <summary>
        /// A language indicator to toogle the 
        /// Always set by the CurrentUICulture by default
        /// </summary>
        public string Lang
        {
            get => lang ?? Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;            
            set { lang = value; }
        }

        /// <summary>
        /// Used to indicate what "slot" the component is in for GCDS
        /// Generally set by the component calling it
        /// </summary>
        public string? Slot { get; set; }
    }
}
