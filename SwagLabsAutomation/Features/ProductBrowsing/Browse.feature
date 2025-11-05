Feature: Products Page browsing
    As a User 
    I want to browse the products
    So I can choose a product to buy
    Scenario: View all products on inventory page
        Given the user is logged in as "standard_user"
        Then I should see all 6 products displayed
        And each product should have a name, description, price, and image
        And each product should have an "Add to cart" button
    