using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestFramework.PageObjects;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class PageTextSteps
    {
        #region Verify_Text_In_Page

        [Then(@"I will verify the text ""(.*)""")]
        public void ThenIWillVerifyTheTextWithTagNameInMode(string text)
        {
            try
            {
               PageText.VerifyPageTextDisplayed(text);
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }
        #endregion
    }
}
