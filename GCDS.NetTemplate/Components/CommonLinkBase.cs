using Microsoft.AspNetCore.Html;
using System.Diagnostics.CodeAnalysis;

namespace GCDS.NetTemplate.Components
{
    public class CommonLinkBase : CommonProps
    {
        public required string Href { get; set; }
        public required IHtmlContent Text { get; set; }

        public CommonLinkBase() { }

        [SetsRequiredMembers]
        public CommonLinkBase(string href, string text)
        {
            Href = href;
            Text = new HtmlString(text);
        }

    }
}
