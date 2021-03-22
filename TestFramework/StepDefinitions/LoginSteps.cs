using System;
using TechTalk.SpecFlow;
using TestFramework.PageObjects;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"I login as ""(.*)"" user")]
        public void GivenILoginAsUser(string userPermissionLevel)
        {
            Login.LoginToSalesforce();
        }

        [Given(@"I enter ""(.*)"", ""(.*)"" and click on ""(.*)"" button on ""(.*)""")]
        public void GivenIEnterAndClickOnButton(string userNameId, string passwordId, string btnTitle,string siteName)
        {
            TextBox.EnterValueInTextboxWithIdProperty(Configurations.salesForceUserName, userNameId);
            TextBox.EnterValueInTextboxWithIdProperty(Configurations.salesForcePassword, passwordId);
            Button.ClickButtonWithValueProperty(btnTitle);
        }

    }
}
