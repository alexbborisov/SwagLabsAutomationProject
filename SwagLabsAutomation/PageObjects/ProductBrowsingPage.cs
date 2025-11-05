using Microsoft.Playwright;

namespace SwagLabsAutomation.PageObjects;

public class ProductBrowsingPage
{

    private readonly IPage _page;

    public ProductBrowsingPage(IPage page)
    {
        _page = page;
    }

    public async Task<int> GetProductCount()
    {
        var locator = _page.Locator(".inventory_item");
        return await locator.CountAsync();
    }

    public async Task VerifyEachProductHasRequiredElements()
    {
        var productLocator = _page.Locator(".inventory_item");
        var allProducts = await productLocator.AllAsync();

        foreach (var product in allProducts)
        {
            var name = product.Locator(".inventory_item_name");
            await Assertions.Expect(name).ToBeVisibleAsync();
            var description = product.Locator(".inventory_item_desc");
            await Assertions.Expect(description).ToBeVisibleAsync();
            var price = product.Locator(".inventory_item_price");
            await Assertions.Expect(price).ToBeVisibleAsync();
            var image = product.Locator("img.inventory_item_img");
            await Assertions.Expect(image).ToBeVisibleAsync();
        }
    }

    public async Task VerifyEachProductHasAddToCartButton()
    {
        var productLocator = _page.Locator(".inventory_item");
        var allProducts = await productLocator.AllAsync();

        foreach (var product in allProducts)
        {
            var button = product.Locator("button");
            await Assertions.Expect(button).ToBeVisibleAsync();
        }
    }
}