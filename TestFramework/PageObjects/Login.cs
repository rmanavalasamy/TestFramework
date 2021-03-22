using OpenQA.Selenium;
using System.Threading;
using TestFramework.Utility;

namespace TestFramework.PageObjects
{
    public class Login
    {
        private static string _userNameFieldName = "username";
        private static string _passwordFieldName = "password";
        private static string _loginBtnValue = "Log In";
        private static string _textFieldWithIdProperty = "//*[@id='{0}']";
        private static string _btnWithValueProperty = "(//*[@value='{0}'])[1]";

        public static void LoginToSalesforce()
        {
            SeleniumOperations.EnterValue(By.XPath(string.Format(_textFieldWithIdProperty, _userNameFieldName)), Configurations.salesForceUserName);
            SeleniumOperations.EnterValue(By.XPath(string.Format(_textFieldWithIdProperty, _passwordFieldName)), Configurations.salesForcePassword);
            SeleniumOperations.ClickOnObject(By.XPath(string.Format(_btnWithValueProperty, _loginBtnValue)));
            Thread.Sleep(7000);
        }


    }
}
