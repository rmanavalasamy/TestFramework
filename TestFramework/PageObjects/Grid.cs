using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TestFramework.Utility;

namespace TestFramework.PageObjects
{
    public class Grid
    {
        #region locators
        private static string _grdDDLField = "((//span[text()='{0}'])[1]/following::div[contains(@class,'dropdown-trigger')]/button[contains(@class,'button_icon-small')])[1] ";
        private static string _grdDDLValue = "((//span[text()='{0}'])[1]/following::ul/li/a[contains(.,'{1}')])[1]";
        private static string _grdItemTxt = "//span[text()='{0}']/following::ul/following::span[text()='{1}']";
        #endregion


        #region ClickOperations
        public static void ClickDropdownValueOnAnalysisGrid(string fieldName, string nameOfGrid)
        {
            SeleniumOperations.ClickOnObjectWithAction(By.XPath(string.Format(_grdDDLField, nameOfGrid)));
            Thread.Sleep(1000);
            SeleniumOperations.ClickOnObjectWithAction(By.XPath(string.Format(_grdDDLValue, nameOfGrid, fieldName)));
        }
        #endregion

        #region VerifyGridItem
        public static void VerifyItemIsAddedToGrid(string item, string gridName)
        {
            Assert.True(SeleniumOperations.IsObjectDisplayed(By.XPath(string.Format(_grdItemTxt, gridName, item))));
        }
        #endregion
    }
}
