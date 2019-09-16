Feature: Users
	To check Users are being retrieved properly from the database

@userstag
Scenario: Show all users
	Given Api is up and running for user test
	When All users requested
	Then Below Users are listed
	| Name         |
	| Nahid Hasan  |
	| Wahid Hasan  |
	| Junaid Hasan |


Scenario: Create a user
	Given Api is up and running to create user
	When User creation requested by information
	| Key			| Value					   |
	| FirstName     | IntegrationTest_User_F01 |
	| LastName      | L01                      |
	| Address       | Volgelwikke 10           |
	| Postcode      | 3434EH                   |
	| City          | Nieuwegein               |
	| AccountNumber | NL01ABNA23456789         |
	| Email         | nahid@email.com          |
	| Phone         | 0616170697               |
	Then User gets created by information
	| Key			| Value									|
	| FirstName     | IntegrationTest_User_F01				|
	| LastName      | L01									|
	| Address       | Volgelwikke 10, 3434EH, Nieuwegein    |
	| AccountNumber | NL01ABNA23456789						|
	| Email         | nahid@email.com						|
	| Phone         | 0616170697							|

Scenario: Delete a user
	Given Api is up and running to delete user
	When User deletion requested by accountNumber NL01ABNA23456789
	Then User gets deleted
	And AccountNumber NL01ABNA23456789 does not exists