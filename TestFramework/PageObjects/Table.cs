using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.Utility;

namespace TestFramework.PageObjects
{
    public class Table
    {
        private static string _tblValue  = "(//th//a[contains(.,'{0}')])";

        public static void VerifyIsDisplayedOnTable(string columnHeader, string value, string tableName)
        {

            Assert.True(SeleniumOperations.IsObjectDisplayed(By.XPath(string.Format(_tblValue, value))));
        }

        public static void ClickOntableRecord(string columnHeader, string value, string tableName)
        {
            SeleniumOperations.ClickOnObjectWithAction(By.XPath(string.Format(_tblValue, value)));
        }

    }
}
