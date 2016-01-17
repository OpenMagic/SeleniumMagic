Feature: GoToPage

Scenario: Valid setup & parameters
	Given I have a webDriver
	When I call GoToPage<TTestPage>(webDriver)
	Then webDriver.Url should be /test