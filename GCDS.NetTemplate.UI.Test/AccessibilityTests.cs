using Microsoft.Playwright;

namespace GCDS.NetTemplate.UI.Test
{
    public class AccessibilityTests
    {
        public static IEnumerable<object[]> ComponentUrls =>
    [
        ["http://localhost:5000/Home/Home"],
        ["http://localhost:5000/Home/Internal"],
        ["http://localhost:5000/Home/Index"],
        // Add more as needed
    ];

        [Theory]
        [MemberData(nameof(ComponentUrls))]
        public async Task Component_Should_Pass_Accessibility_Check(string url)
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
            var page = await browser.NewPageAsync();

            await AccessibilityChecker.CheckAccessibilityAsync(page, url);
        }
    }
}