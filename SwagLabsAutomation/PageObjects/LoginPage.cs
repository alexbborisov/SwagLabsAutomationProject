using Microsoft.Playwright;

namespace SwagLabsAutomation.PageObjects;

public class LoginPage
{
    private readonly IPage _page;

    private ILocator UsernameInput => _page.Locator("#user-name");
    private ILocator PasswordInput => _page.Locator("#password");
    private ILocator LoginButton => _page.Locator("#login-button");
    private ILocator ProductsTitle => _page.Locator("div.product_label");

    private ILocator ErrorMessage => _page.Locator("button[class='error-button']");

    public LoginPage(IPage page)
    {
        _page = page;
    }

    public async Task NavigateToLoginPage()
    {
        await _page.GotoAsync("https://www.saucedemo.com/v1/index.html");
    }

    public async Task EnterUsername(string username)
    {
        await UsernameInput.FillAsync(username);
    }

    public async Task EnterPassword(string password)
    {
        await PasswordInput.FillAsync(password);
    }

    public async Task ClickLoginButton()
    {
        await LoginButton.ClickAsync();
    }

    public async Task IsOnProductPage()
    {
        await Assertions.Expect(ProductsTitle).ToBeVisibleAsync();
    }

    public async Task IsOnLoginPage()
    {
        await Assertions.Expect(_page).ToHaveURLAsync("https://www.saucedemo.com/v1/index.html");
    }

    public async Task IsErrorMessageDisplayed()
    {
        await Assertions.Expect(ErrorMessage).ToBeVisibleAsync();
    }
}

