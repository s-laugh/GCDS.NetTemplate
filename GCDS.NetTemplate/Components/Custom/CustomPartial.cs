using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GCDS.NetTemplate.Components.Custom
{
    public class CustomPartial : IHeaderSkipSlot
    {
        /// <summary>
        /// Name of the view to render
        /// </summary>
        public required string ViewName { get; set; }

        /// <summary>
        /// Optional Model to pass to the view
        /// </summary>
        public object? Model { get; set; }

        /// <summary>
        /// Optional additional data to pass to the view
        /// </summary>
        public ViewDataDictionary? ViewData { get; set; }
    }
}
