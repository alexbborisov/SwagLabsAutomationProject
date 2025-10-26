using Microsoft.Playwright;

namespace SwagLabsAutomation;

public class BrowserContext
{
    public IPlaywright? Playwright { get; set; }
    public IBrowser? Browser { get; set; }
    public IPage? Page { get; set; }
}