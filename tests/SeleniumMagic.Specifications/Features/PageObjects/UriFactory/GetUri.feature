Feature: GetUri

Scenario: Index page
	Given TPageObject is in PageObjects namespace
	And TPageObject is *.PageObjects.Test.Index
    And currentUri is http://fake:540
	When I call GetUri<TPageObject>(Uri currentUri)
	Then the Uri should be http://fake:540/test

Scenario: Non-index page
	Given TPageObject is in PageObjects namespace
	And TPageObject is *.PageObjects.Test.Other
    And currentUri is http://fake:50/a/random/folder/
	When I call GetUri<TPageObject>(Uri currentUri)
	Then the Uri should be http://fake:50/test/other