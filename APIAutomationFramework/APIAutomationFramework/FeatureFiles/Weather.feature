Feature: Weather

Scenario Outline: Current weather for different cities across the world
	Given I run the weather api for city : '<city>'
	Then I verify that the api is run successfully
	Then I verify the location values returned : '<name>','<country>','<region>'

	Examples:
		| city      | name      | country                  | region |
		| Houston   | Houston   | United States of America | Texas  |
		| New Delhi | New Delhi | India                    | Delhi  |