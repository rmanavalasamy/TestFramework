using System;
using TechTalk.SpecFlow;
using TestFramework.PageObjects;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class TextboxSteps
    {
        [When(@"I enter the value ""(.*)"" in ""(.*)"" textbox on ""(.*)"" modal popup")]
        public void WhenIEnterTheValueInTextboxOnModalPopup(string value, string textBoxName, string modal)
        {
            TextBox.EnterTheValueInTextboxOnModalPopup(value, textBoxName, modal);
        }

        [When(@"I enter the value ""(.*)"" in summary textbox on ""(.*)"" modal popup")]
        public void WhenIEnterTheValueInSumaryTextboxOnModalPopup(string value, string modal)
        {
            TextBox.EnterTheValueInSummaryTextboxOnModalPopup(value, modal);
        }


    }
}
