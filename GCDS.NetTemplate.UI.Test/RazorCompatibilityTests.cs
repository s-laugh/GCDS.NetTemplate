using Microsoft.Playwright;

namespace GCDS.NetTemplate.UI.Test
{
    public class RazorCompatibilityTests
    {
        private static readonly string BasePath = "http://localhost:5120/";

        [Theory]
        [InlineData("")]
        [InlineData("Internal")]
        [InlineData("InternalSideNav")]
        public async Task RazorPage_Should_Render_WithoutErrors(string url)
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
            var page = await browser.NewPageAsync();

            var response = await page.GotoAsync($"{BasePath}{url}", 
                new() { WaitUntil = WaitUntilState.NetworkIdle });
            Assert.NotNull(response);
            Assert.True(response.Ok, $"Failed to load {url}: {response.Status}");
        }
    }
}
