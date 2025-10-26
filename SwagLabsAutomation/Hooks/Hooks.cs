using Microsoft.Playwright;
using Reqnroll;

namespace SwagLabsAutomation.Hooks;

[Binding]
public class Hooks
{
    [BeforeScenario]
    public async Task BeforeScenario(BrowserContext browserContext)
    {
        browserContext.Playwright = await Playwright.CreateAsync();
        browserContext.Browser = await browserContext.Playwright.Chromium.LaunchAsync(new()
        {
            Headless = false, 
            SlowMo = 1000
        });
        browserContext.Page = await browserContext.Browser.NewPageAsync();
    }

    [AfterScenario]
    public async Task AfterScenario(BrowserContext browserContext)
    {
        await browserContext.Browser!.CloseAsync();
        browserContext.Playwright!.Dispose();
    }
}