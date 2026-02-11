using Deque.AxeCore.Playwright;
using Microsoft.Playwright;

namespace GCDS.NetTemplate.UI.Test;

[Collection("pw")]
public class AccessibilityTests(PlaywrightFixture fx)
{
    private readonly IPage Page = fx.Page;

    [Theory]
    [InlineData("/Home/Index")]
    [InlineData("/Home/Home")]
    [InlineData("/Home/SideNav")]
    [InlineData("/Home/Internal")]
    [InlineData("/Home/AltInternal")]
    [InlineData("/Home/InternalSideNav")]
    [InlineData("/Home/InternalSideNav?variant=true")]
    [InlineData("/Home/AltInternalSideNav")]
    public async Task Component_Should_Pass_Accessibility_Check(string path)
    {
        await Page.GotoAsync(path, new() { WaitUntil = WaitUntilState.NetworkIdle });

        var result = await Page.RunAxe();

        Assert.True(result.Violations.Length == 0,
            $"Accessibility violations found at {path}:\n{result}");

    }
}
