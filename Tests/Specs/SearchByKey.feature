Feature: Search By Key
	In order to directly find an entity by typing the url
	As a user
	I want to enter a simplier key than the entity unique ID

Scenario: A project key is based on his name
	Given a project named 'MyProj'
	Then the key should be 'MyProj'

