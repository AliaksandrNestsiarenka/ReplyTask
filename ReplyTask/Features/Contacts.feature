Feature: Contacts

Scenario: Create a contact
	  Given I am an admin user
	  Given I have a new contact information
	  When I log in
	  And I navigate to contacts
	  And I create a new contact
	  Then Created contact details matches with the contact information
	  
	  




