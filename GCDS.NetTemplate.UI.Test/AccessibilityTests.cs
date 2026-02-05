using Microsoft.Playwright;

namespace GCDS.NetTemplate.UI.Test
{
    public class AccessibilityTests
    {
        public static IEnumerable<object[]> ComponentUrls =>
        [
            ["http://localhost:5000/Home/Index"],
            ["http://localhost:5000/Home/Home"],
            ["http://localhost:5000/Home/SideNav"],
            ["http://localhost:5000/Home/Internal"],
            ["http://localhost:5000/Home/AltInternal"],
            ["http://localhost:5000/Home/InternalSideNav"],
            ["http://localhost:5000/Home/InternalSideNav?variant=true"],
            ["http://localhost:5000/Home/AltInternalSideNav"],
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