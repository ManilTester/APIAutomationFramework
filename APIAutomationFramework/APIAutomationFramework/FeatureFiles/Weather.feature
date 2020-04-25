Feature: Weather

Scenario Outline: Verify location data returned from Current Weather Endpoint
	Given I run the weather api for city : '<city>'
	Then I verify that the api has run successfully
	Then I verify the location values returned : '<name>','<country>','<region>'

	Examples:
		| city      | name      | country                  | region |
		| Houston   | Houston   | United States of America | Texas  |
		| New Delhi | New Delhi | India                    | Delhi  |