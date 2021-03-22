using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TestFramework.SpecFlowLibraries;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions.Generic_Control_Step_Definitions
{
    [Binding]
    public sealed class BrowserNavigationSteps
    {

        #region Navigate_To_Page
        [Given(@"I navigate to the site")]
        public void GivenINavigateToTheSite()
        {
            try
            {
                Hooks.driver.Navigate().GoToUrl(Configurations.siteURL);
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }
        [When(@"I navigate to the site")]
        public void WhenINavigateToTheSite()
        {
            try
            {
                Hooks.driver.Navigate().GoToUrl(Configurations.siteURL);
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }
        #endregion

        #region Refresh_Current_Page

        [When(@"I refresh the current page")]
        public void WhenIRefreshTheCurrentPage()
        {
            try
            {
                Thread.Sleep(10000);
                Hooks.driver.Navigate().Refresh();
                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }
        #endregion

        #region Navigate_To_Forward_Page

        [When(@"I navigate to forward page")]
        public void WhenINavigateToForwardPage()
        {
            try
            {
                Hooks.driver.Navigate().Forward();
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }

        #endregion

        #region Navigate_To_Backward_Page

        [When(@"I navigate to backward page")]
        public void WhenINavigateToBackwardPage()
        {
            try
            {
                Hooks.driver.Navigate().Back();
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }

        #endregion


    }
}

