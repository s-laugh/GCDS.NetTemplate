using Microsoft.Playwright;

namespace GCDS.NetTemplate.UI.Test;

[CollectionDefinition("pw")]
public class PlaywrightCollection : ICollectionFixture<PlaywrightFixture> { }

public class PlaywrightFixture : IAsyncLifetime
{
    public IPlaywright PW { get; private set; } = default!;
    public IBrowser Browser { get; private set; } = default!;
    public IBrowserContext Context { get; private set; } = default!;
    public IPage Page { get; private set; } = default!;

    public string BaseUrl { get; } =
            Environment.GetEnvironmentVariable("BASE_URL")
            ?? "http://localhost:5110";

    public async Task InitializeAsync()
    {
        PW = await Playwright.CreateAsync();
        Browser = await PW.Chromium.LaunchAsync(new() { Headless = true });
        Context = await Browser.NewContextAsync(new() { 
            BaseURL = BaseUrl, 
            IgnoreHTTPSErrors = true });
        Page = await Context.NewPageAsync();
    }

    public async Task DisposeAsync()
    {
        await Page.CloseAsync();
        await Context.CloseAsync();
        await Browser.CloseAsync();
        PW.Dispose();
    }
}
