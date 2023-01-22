@tag1
Feature: AppTests

A short summary of the feature
Scenario: date picker
	Given the user picks 1/21/2023 for the first date
	And the user picks 1/22/2023 for the second date
	When the See All Room Types button is clicked
	Then the number of rooms available is 1
