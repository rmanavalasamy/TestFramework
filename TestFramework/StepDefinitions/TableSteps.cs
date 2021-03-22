using System;
using TechTalk.SpecFlow;
using Table = TestFramework.PageObjects.Table;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class TableSteps
    {

        [Then(@"I verify ""(.*)"", ""(.*)"" is displayed on ""(.*)"" table")]
        public void ThenIVerifyIsDisplayedOnTable(string columnHeader, string value, string tableName)
        {
            Table.VerifyIsDisplayedOnTable(columnHeader,value,tableName);
        }

        [When(@"I click ""(.*)"", ""(.*)"" on ""(.*)"" table")]
        public void WhenIClickOnTable(string columnHeader, string value, string tableName)
        {
            Table.ClickOntableRecord(columnHeader, value, tableName);
        }

    }
}
