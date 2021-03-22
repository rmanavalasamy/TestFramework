Feature: CRUSH_AccountPlan
	CRUSH_AccountPlan test cases


@regression
Scenario: (1) Create_New_Account_Plan
	Given I am on url "Salesforce"
	And I enter "username", "password" and click on "Log In" button on "salesforce"
	When I search on "Search apps" searchbar and select "PROLIFIQ CRUSH"
	And I click "Account Plans" on top navigation menu
	And I click on "New" button 
	And I enter the value "Demo" in "Account Plan Name" textbox on "New Account Plan" modal popup
	And I enter the value "test" in summary textbox on "New Account Plan" modal popup
	And I select the option "Open" from "Status" dropdown on "New Account Plan" modal popup
	And I select the option "Grow" from "Goal" dropdown on "New Account Plan" modal popup
	And I search on "Account" combobox and select "DemoAccount" on "New Account Plan" modal popup
	And I click on "Save" button on "New Account Plan" modal popup
	And I click "Account Plans" on top navigation menu
	Then I verify "Account Plan Name", "Demo" is displayed on "Account Plans" table

@regression
Scenario: (2) Edit_Existing_Account_Plan 
	Given I am on url "Salesforce"
	And I enter "username", "password" and click on "Log In" button on "salesforce"
	When I search on "Search apps" searchbar and select "PROLIFIQ CRUSH"
	And I click "Account Plans" on top navigation menu
	And I click "Account Plan Name", "Demo" on "Account Plans" table
	And I click on "Edit" button
	And I enter the value "DemoEdited" in "Account Plan Name" textbox on "Edit Demo" modal popup
	And I enter the value "summary edited" in summary textbox on "Edit Demo" modal popup
	And I click on "Save" button on "Edit Demo" modal popup
	And I click "Account Plans" on top navigation menu
	Then I verify "Account Plan Name", "DemoEdited" is displayed on "Account Plans" table

@regression
Scenario: (3) Create_SWOT_Analysis
	Given I am on url "Salesforce"
	And I enter "username", "password" and click on "Log In" button on "salesforce"
	When I search on "Search apps" searchbar and select "PROLIFIQ CRUSH"
	And I click "Account Plans" on top navigation menu
	And I click "Account Plan Name", "DemoEdited" on "Account Plans" table
	And I click "SWOT" on top navigation menu
	#Strengths
	And I click "Add" on "Strengths" analysis grid
	And I enter the value "test" in "Name" textbox on "Create SWOT Analysis Item" modal popup
	And I enter the value "testsum" in summary textbox on "Create SWOT Analysis Item" modal popup
	And I click on "Save" button on "Create SWOT Analysis Item" modal popup
	And I Verify SWOT analysis item "test" is added to "Strengths" grid
	#Opportunities
	And I click "Add" on "Opportunities" analysis grid
	And I enter the value "test" in "Name" textbox on "Create SWOT Analysis Item" modal popup
	And I enter the value "testsum" in summary textbox on "Create SWOT Analysis Item" modal popup
	And I click on "Save" button on "Create SWOT Analysis Item" modal popup
	And I Verify SWOT analysis item "test" is added to "Opportunities" grid
	#Weaknesses
	And I click "Add" on "Weaknesses" analysis grid
	And I enter the value "test" in "Name" textbox on "Create SWOT Analysis Item" modal popup
	And I enter the value "testsum" in summary textbox on "Create SWOT Analysis Item" modal popup
	And I click on "Save" button on "Create SWOT Analysis Item" modal popup
	And I Verify SWOT analysis item "test" is added to "Weaknesses" grid
	#Threats
	And I click "Add" on "Threats" analysis grid
	And I enter the value "test" in "Name" textbox on "Create SWOT Analysis Item" modal popup
	And I enter the value "testsum" in summary textbox on "Create SWOT Analysis Item" modal popup
	And I click on "Save" button on "Create SWOT Analysis Item" modal popup
	And I Verify SWOT analysis item "test" is added to "Threats" grid

#Delete created acc and run
@regression
Scenario: (4) Create_New_Account_Plan_With_NewAccount
	Given I am on url "Salesforce"
	And I enter "username", "password" and click on "Log In" button on "salesforce"
	When I search on "Search apps" searchbar and select "PROLIFIQ CRUSH"
	And I click "Account Plans" on top navigation menu
	And I click on "New" button 
	And I enter the value "DemoNew" in "Account Plan Name" textbox on "New Account Plan" modal popup
	And I enter the value "test" in summary textbox on "New Account Plan" modal popup
	And I select the option "Open" from "Status" dropdown on "New Account Plan" modal popup
	And I select the option "Grow" from "Goal" dropdown on "New Account Plan" modal popup
	And I search on "Account" combobox and select "New Account" on "New Account Plan" modal popup
	And I enter the value "TestAcc" in "Account Name" textbox on "New Account" modal popup
	And I click on "Save" button on "New Account" modal popup
	And I click on "Save" button on "New Account Plan" modal popup
	And I click "Account Plans" on top navigation menu
	Then I verify "Account Plan Name", "DemoNew" is displayed on "Account Plans" table

#Below scenario is just to test xpaths
#Scenario: Test_Xpaths
#	Given I am on url "Salesforce"
#	And I login as "test" user
#	When I search on "Search apps" searchbar and select "PROLIFIQ CRUSH"
#	When I test xpaths
