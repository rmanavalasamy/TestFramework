using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestFramework.PageObjects;
using TestFramework.SpecFlowLibraries;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions.Generic_Control_Step_Definitions
{
    [Binding]
    public sealed class BrowserNavigationStepDef
    {
        #region Navigate_To_Page
        [Given(@"I am on url ""(.*)""")]
        public void GivenIAmOnUrl(string urlName)
        {
            BrowserNavigation.NavigateToTheUrl(urlName);
        }

        #endregion

        #region Refresh_Current_Page

        [When(@"I refresh the current page")]
        public void WhenIRefreshTheCurrentPage()
        {
  
            Thread.Sleep(10000);
            Hooks.driver.Navigate().Refresh();
            Thread.Sleep(10000);
        }
        #endregion

        #region Navigate_To_Forward_Page

        [When(@"I navigate to forward page")]
        public void WhenINavigateToForwardPage()
        {

            Hooks.driver.Navigate().Forward();
        }

        #endregion

        #region Navigate_To_Backward_Page

        [When(@"I navigate to backward page")]
        public void WhenINavigateToBackwardPage()
        {
 
           Hooks.driver.Navigate().Back();
        }
        #endregion
    }
}

