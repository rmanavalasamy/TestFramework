using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestFramework.PageObjects;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    class ButtonStepDef
    {

        [When(@"I test xpaths")]
        public void WhenITestXpaths()
        {
            SeleniumOperations.xpaths();
        }



        #region Click_On_Button

        [When(@"I click on ""(.*)"" button")]
        public static void WhenIClickButton(string text)
        {

            Button.ClickButtonWithTextProperty(text);
        }

        #endregion

        #region Button_On_modal_popup
        [When(@"I click on ""(.*)"" button on ""(.*)"" modal popup")]
        public void WhenIClickOnButtonOnOnModalPopup(string fieldName, string modal)
        {

            Button.ClickOnButtonOnModalPopup(fieldName, modal);
            Thread.Sleep(5000);
        }

        #endregion

        #region Click_On_Button_With_Value_Property

        [When(@"I click on ""(.*)"" button with value property")]
        public static void WhenIClickOnButtonWithValueProperty(string fieldName)
        {
            Button.ClickButtonWithValueProperty(fieldName);
        }

        #endregion

        #region Click_On_Button_With_Id_Property

        [When(@"I click on ""(.*)"" button with id property")]
        public static void WhenIClickOnButtonWithIdProperty(string idName)
        {
            Button.ClickButtonWithIdProperty(idName);
        }

        #endregion

        #region Verify_Button_State

        [Then(@"I will verify ""(.*)"" button in ""(.*)"" mode")]
        public static void ThenIWillVerifyButtonInMode(string fieldName, string mode)
        {

            Button.VerifyButtonState(fieldName, mode);
        }

        #endregion
    }
}
