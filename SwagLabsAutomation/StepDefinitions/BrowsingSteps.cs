using NUnit.Framework;
using Reqnroll;
using SwagLabsAutomation.PageObjects;

namespace SwagLabsAutomation.StepDefinitions;

[Binding]

public class BrowsingSteps
{
    private readonly BrowserContext _browserContext;
    private readonly LoginPage _loginPage;
    private readonly ProductBrowsingPage _productBrowsingPage;

    public BrowsingSteps(BrowserContext browserContext)
    {
        _browserContext = browserContext;
        _loginPage = new LoginPage(_browserContext.Page!);
        _productBrowsingPage = new ProductBrowsingPage(_browserContext.Page!);
    }
    

    [Then("I should see all {int} products displayed")]
    public async Task ThenIShouldSeeAllProductsDisplayed(int expectedCount)
    {
        var actualCount = await _productBrowsingPage.GetProductCount();
        Assert.That(actualCount, Is.EqualTo(expectedCount));
    }

    [Then("each product should have a name, description, price, and image")]
    public async Task ThenEachProductShouldHaveANameDescriptionPriceAndImage()
    {
        await _productBrowsingPage.VerifyEachProductHasRequiredElements();
    }

    [Then("each product should have an \"Add to cart\" button")]
    public async Task ThenEachProductShouldHaveAnButton()
    {
        await _productBrowsingPage.VerifyEachProductHasAddToCartButton();
    }
}
