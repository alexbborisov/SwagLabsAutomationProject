Feature: Products Page Functionality
    As a user 
    I want to browser the product catalog
    So that I can add/remove a product to the cart and
    check product prices
    @smoke @product
   Scenario: Adding a product to card
       Given the user is logged in as "standard_user"
       And the user is on product catalog page
       When the user adds "Sauce Labs Backpack" to cart
       Then the cart badge shows "1"
       And remove button is displayed for "Sauce Labs Backpack"
