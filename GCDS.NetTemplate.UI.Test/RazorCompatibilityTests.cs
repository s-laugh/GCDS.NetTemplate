using Microsoft.Playwright;

namespace GCDS.NetTemplate.UI.Test
{
    public class RazorCompatibilityTests
    {
        [Theory]
        [InlineData("http://localhost:5001/")]
        [InlineData("http://localhost:5001/Internal")]
        public async Task RazorPage_Should_Render_WithoutErrors(string url)
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
            var page = await browser.NewPageAsync();

            var response = await page.GotoAsync(url);
            Assert.NotNull(response);
            Assert.True(response.Ok, $"Failed to load {url}: {response.Status}");
        }
    }
}
