using System;
using TechTalk.SpecFlow;
using TestFramework.PageObjects.Specific_Page_Objects;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions.Specific_Page_Steps
{
    [Binding]
    public class CRUSH_Navigation_Steps
    {
        [When(@"I search on ""(.*)"" searchbar and select ""(.*)""")]
        public void WhenISearchAndselect(string placeHoldername,string appName)
        {
            CRUSH_Navigation.SearchAndNavigateToTheApp(placeHoldername, appName);
        }

        [When(@"I click ""(.*)"" on top navigation menu")]
        public void WhenIClickOnTopNavigationMenu(string menu)
        {

            CRUSH_Navigation.ClickMenuOnTopNavigationBar(menu);
        }

    }
}
