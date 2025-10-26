using Microsoft.Playwright;

namespace SwagLabsAutomation.PageObjects;

public class ProductsPage
{
    private readonly IPage _page;

    public ProductsPage(IPage page)
    {
        _page = page;
    }

    public ILocator CartBadge => _page.Locator(".shopping_cart_badge");
    public ILocator GetAddToCartButton(string productName)
    {
        var productContainer = _page.Locator(".inventory_item")
            .Filter(new() { HasText = productName });
        var button = productContainer.Locator("button");
        return button;
    }

    public async Task AddProductToCart(string productName)
    {
        await GetAddToCartButton(productName).ClickAsync();
    }

    public async Task<string?> GetCartBadgeCount()
    {
        return await CartBadge.TextContentAsync();
    }

    public async Task VerifyRemoveButtonVisible(string productName)
    {
        var button = GetAddToCartButton(productName);
        await Assertions.Expect(button).ToHaveTextAsync("REMOVE");
    }

}