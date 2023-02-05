Feature: CRMCloud
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](ReplyTask/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

Scenario: Create a contact
	  Given I am an admin user
	  Given I have a new contact information
	  When I log in
	  And I navigate to Sales&Marketing tab
	  And I create a new contact
	  Then Created contact details matches with the contact information
	  
	  




