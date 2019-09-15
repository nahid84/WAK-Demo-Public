Feature: Users
	To check Users are being correctly properly from the database

@userstag
Scenario: Show all users
	Given Api is up and running for user test
	When All users requested
	Then Below Users are listed
	| Name         |
	| Nahid Hasan  |
	| Wahid Hasan  |
	| Junaid Hasan |
	
