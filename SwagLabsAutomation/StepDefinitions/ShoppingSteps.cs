using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll;
using SwagLabsAutomation.PageObjects;

namespace SwagLabsAutomation.StepDefinitions;

[Binding]
public class ShoppingSteps
{
    private readonly BrowserContext _browserContext;
    private readonly LoginPage _loginpage;
    private readonly ProductsPage _productsPage;

    public ShoppingSteps(BrowserContext browserContext)
    {
        _browserContext = browserContext;
        _loginpage = new LoginPage(_browserContext.Page!);
        _productsPage = new ProductsPage(_browserContext.Page!);
    }
    
    [When("the user adds {string} to cart")]
    public async Task WhenTheUserAddsToCart(string productName)
    {
        await _productsPage.AddProductToCart(productName);
    }

    [Then("the cart badge shows {string}")]
    public async Task ThenTheCartBadgeShows(string count)
    {
        var actualCount = await _productsPage.GetCartBadgeCount();
        Assert.That(actualCount, Is.EqualTo(count));
    }

    [Then("remove button is displayed for {string}")]
    public async Task ThenRemoveButtonIsDisplayedFor(string productName)
    {
        await _productsPage.VerifyRemoveButtonVisible(productName);
    }
}