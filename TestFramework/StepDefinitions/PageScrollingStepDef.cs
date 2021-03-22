using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class PageScrollingStepDef
    {
        [When(@"I scroll down to the bottom of page")]
        public static void WhenIScrollToBottomOfPage()
        {
            SeleniumOperations.ScrollDownThePage();
        }
        
    }
}
