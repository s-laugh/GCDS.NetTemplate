using GCDS.NetTemplate.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GCDS.NetTemplate.Razor.Sanity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            HttpContext.SetTemplateCulture(Constants.ENGLISH_CULTURE);
        }
    }
}
