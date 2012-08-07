Feature: UserStory
	In order to manage product features
	As a team member
	I want to be able to manage user stories

Scenario: I should be hable to uniquely identify a user story
	Given I have a story
	Then It should have a unique key

Scenario: A user story should have a text
    Given I have a story
    Then I should be hable to define its text

Scenario: A new user story should start with a template
    When I create a new story
    Then the story should follow this template 'As a <role>, I want <goal/desire> so that <benefit>'

Scenario: I should be hable to estimate the effort for a story
    Given I have a story
    Then I should be able to assign an 'Effort' as integer