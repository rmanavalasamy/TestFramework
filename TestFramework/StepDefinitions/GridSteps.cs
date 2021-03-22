using System;
using TechTalk.SpecFlow;
using TestFramework.PageObjects;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class GridSteps
    {
        [When(@"I click ""(.*)"" on ""(.*)"" analysis grid")]
        public void WhenIClickOnOnAnalysisGrid(string fieldName, string nameOfGrid)
        {
            Grid.ClickDropdownValueOnAnalysisGrid(fieldName, nameOfGrid);
        }

        [When(@"I Verify SWOT analysis item ""(.*)"" is added to ""(.*)"" grid")]
        public void WhenIVerifySWOTAnalysisItemIsAddedToGrid(string item, string gridName)
        {
            Grid.VerifyItemIsAddedToGrid(item, gridName);
        }

    }

}
