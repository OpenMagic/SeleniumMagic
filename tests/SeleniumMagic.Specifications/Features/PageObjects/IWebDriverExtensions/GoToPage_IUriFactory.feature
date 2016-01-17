Feature: GoToPage(IUriFactory)

Scenario: Valid setup & parameters
	Given I have a webDriver
	And I have a uriFactory
	When I call GoToPage<TTestPage>(webDriver, uriFactory)
	Then webDriver.Url should be /test