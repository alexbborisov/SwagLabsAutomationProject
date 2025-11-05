Feature: Swag Labs Login form feature
As a user
I want to log into Swag Labs
So that I can access the product catalog

    @login @smoke
    Scenario: Successful login with valid credentials
        Given the user is on the login page
        When user enters username "standard_user"
        And user enters password "secret_sauce"
        And user clicks on Login button
        Then user is redirected to products page
        And the products page title should be visible
    @login @negative 
    Scenario: Login attempt with locked out user
        Given the user is on the login page
        When user enters username "locked_out_user"
        And user enters password "secret_sauce"
        And user clicks on Login button
        Then user remains on the login page
        And an error message is displayed
                