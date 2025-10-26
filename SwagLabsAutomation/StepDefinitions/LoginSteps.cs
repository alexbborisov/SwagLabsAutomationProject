
using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Reqnroll;
using SwagLabsAutomation.PageObjects;


namespace SwagLabsAutomation.StepDefinitions;

[Binding]
public class LoginSteps
{
    private readonly BrowserContext _browserContext;
    private readonly LoginPage _loginPage;

    public LoginSteps(BrowserContext browserContext)
    {
        _browserContext = browserContext;
        _loginPage = new LoginPage(_browserContext.Page!);
    }
    
    [Given("the user is on the login page")]
    public async Task GivenTheUserIsOnTheLoginPage()
    {
        await _loginPage.NavigateToLoginPage();
    }

    [When("user enters username {string}")]
    public async Task WhenUserEntersUsername(string username)
    {
        await _loginPage.EnterUsername(username);
    }
    
    [When("user enters password {string}")]
    public async Task WhenUserEntersPassword(string password)
    {
        await _loginPage.EnterPassword(password);
    }

    [When("user clicks on Login button")]
    public async Task WhenUserClicksOnLoginButton()
    {
        await _loginPage.ClickLoginButton();
    }

    [Then("user is redirected to products page")]
    public async Task ThenUserIsRedirectedToProductsPage()
    {
        await Assertions.Expect(_browserContext.Page).ToHaveURLAsync(new Regex(".*inventory.*"));

    }

    [Then("the products page title should be visible")]
    public async Task ThenTheProductsPageTitleShouldBeVisible()
    {
        await _loginPage.IsOnProductPage();
    }

    [Then("user remains on the login page")]
    public async Task ThenUserRemainsOnTheLoginPage()
    {
        await _loginPage.IsOnLoginPage();
    }

    [Then("an error message is displayed")]
    public async Task ThenAnErrorMessageIsDisplayed()
    {
        await _loginPage.IsErrorMessageDisplayed();
    }
}