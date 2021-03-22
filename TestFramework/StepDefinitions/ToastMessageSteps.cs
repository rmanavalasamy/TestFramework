using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestFramework.PageObjects;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class ToastMessageSteps
    {

        [When(@"I verify the Account plan was saved toast alert is displayed")]
        public void WhenIVerifyTheAccountPlanWasSavedToastAlertIsDisplayed()
        {
            try
            {
                Assert.True(ToastMessage.IsToastAlertDisplayed());
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }


    }
}
