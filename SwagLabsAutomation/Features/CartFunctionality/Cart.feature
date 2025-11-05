Feature: Shopping Cart functionality
    As a user
    I want to add/remove products from cart
    So that I can buy a product from the website
    @smoke @product
   Scenario: Adding a product to card
       Given the user is logged in as "standard_user"
       When the user adds "Sauce Labs Backpack" to cart
       Then the cart badge shows "1"
       And remove button is displayed for "Sauce Labs Backpack"
