using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestFramework.PageObjects;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class LinkStepDef
    {
        #region Click_Link

        [When(@"I click ""(.*)"" link")]
        public static void WhenIClickLink(string fieldName)
        {
            Link.ClickOnLinkByText(fieldName);
        }

        #endregion

        #region Verify_Link_Displayed

        [Then(@"I will verify the link ""(.*)"" displayed")]
        public static void ThenIWillVerifyTheLinkDisplayed(string fieldName)
        {
            Assert.True(Link.IsLinkDisplayed(fieldName));
        }
        #endregion
    }
}
