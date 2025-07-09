using Microsoft.Playwright;

namespace GCDS.NetTemplate.UI.Test
{
    public static class AccessibilityChecker
    {
        public static async Task CheckAccessibilityAsync(IPage page, string url)
        {
            await page.GotoAsync(url);
            await page.AddScriptTagAsync(new() { Url = "https://cdnjs.cloudflare.com/ajax/libs/axe-core/4.4.1/axe.min.js" });

            var resultJson = await page.EvaluateAsync<string>("async () => JSON.stringify(await axe.run())");
            var result = System.Text.Json.JsonDocument.Parse(resultJson);

            if (result.RootElement.TryGetProperty("violations", out var violations) && violations.GetArrayLength() > 0)
            {
                var sb = new System.Text.StringBuilder();
                sb.AppendLine("====================");
                sb.AppendLine($"\n❌ Accessibility issues found on: {url}");

                foreach (var violation in violations.EnumerateArray())
                {
                    var rule = violation.GetProperty("id").GetString();
                    var help = violation.GetProperty("help").GetString();
                    var nodes = violation.GetProperty("nodes");

                    sb.AppendLine($"  • Rule: {rule} — {help}");
                    foreach (var node in nodes.EnumerateArray())
                    {
                        var html = node.GetProperty("html").GetString()?.Trim();
                        html = System.Net.WebUtility.HtmlDecode(html);
                        sb.AppendLine($"    ↳ {html}");
                    }
                }

                sb.AppendLine("====================");
                Console.WriteLine(sb.ToString());
                throw new Exception($"Accessibility violations found on {url}");
            }
            else
            {
                Console.WriteLine($"✅ No accessibility violations found on: {url}");
            }
        }
    }
}