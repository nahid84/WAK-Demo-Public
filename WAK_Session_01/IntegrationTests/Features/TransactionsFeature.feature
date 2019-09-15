Feature: TransactionsFeature
	To check Transactions are being properly retrieved from the database

@transactionstag
Scenario: Show all transactions for a user
	Given Api is up and running for transaction test
	When Transaction requested by accountnumber NL09ABNA1111112234
	Then Below transactions are listed
	| Indication | Amount |
	| debit      | 100    |
	| credit     | 200    |
