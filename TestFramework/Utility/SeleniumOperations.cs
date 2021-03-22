using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TestFramework.SpecFlowLibraries;

namespace TestFramework.Utility
{
    public class SeleniumOperations
    {

        #region Variable_Declarations
        private static IWebElement element = null;
        private static IList<IWebElement> objElements;
        public static int timeoutValue = Configurations.driverWaitTime;
        public static int timeoutValueForElementDisplayed = Configurations.explicitWaitTime;
        public static IAlert alert;
        static string mainWindowHandle;
        #endregion


        public static void xpaths()
        {
            WebDriverWait wait = new WebDriverWait(Hooks.driver, TimeSpan.FromSeconds(timeoutValue));
            By xpath1 = By.XPath("//h2[text()='New Account Plan']//following::label[text()='Account']/following::input[@role='combobox'][1]");
            By xpath2 = By.XPath("//span[contains(@class,'listbox__option') and contains(.,'DemoAccount')][1]");

            Actions ac = new Actions(Hooks.driver);
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(xpath1));
            ac.MoveToElement(element).Click().SendKeys("DemoAccount").Build().Perform();
            IWebElement element2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(xpath2));
            Actions ac1 = new Actions(Hooks.driver);
            ac1.MoveToElement(element2).Click().Build().Perform();         
        }

        #region methods

        public static void NavigateToTheSite(string siteUrl)
        {
            try
            {
                Hooks.driver.Navigate().GoToUrl(siteUrl);
            }
            catch { throw; }
        }

        public static MediaEntityModelProvider CaptureScreenshotAndReturnString(string name)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)Hooks.driver).GetScreenshot().AsBase64EncodedString;
                return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
            }
            catch { throw; }          
        }

        #region Generic_Methods

        public static bool IsObjectDisplayed(By xpath, string modalName = "")
        {
            objElements = WaitForElementsToBeDisplayed(xpath);
            if (objElements.Count > 0)
            {
                if (string.IsNullOrEmpty(modalName))
                {
                    HighlightElement(objElements[0]);
                }
                return objElements[0].Displayed;
            }
            else
            {
                return false;
            }
        }
        public static int GetObjectsCount(By xpath)
        {
            return WaitForElementsToBeDisplayed(xpath).Count;

        }
        public static void ClickOnObject(By xpath)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                element.Click();
                Thread.Sleep(3000);
            }
            catch { throw; }
        }
        public static string GetObjectText(By xpath)
        {
            try
            {
                element = WaitForElementToBeDisplayed(xpath);
                HighlightElement(element);
                return element.Text.Trim();
            }
            catch { throw; }
        }
        public static string GetDropdownSelectedText(By xpath)
        {
            try
            {
                element = WaitForElementToBeDisplayed(xpath);
                HighlightElement(element);
                if (element.Selected)
                {
                    return element.Text.Trim();
                }
                return null;
            }
            catch { throw; }
        }
        public static void EnterValue(By xpath, string value)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
                element.SendKeys(value);
            }
            catch { throw; }
        }


        public static void EnterValueWithAction(By xpath, string value)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                Actions action = new Actions(Hooks.driver);
                action.MoveToElement(element).SendKeys(value).Build().Perform();
            }
            catch { throw; }
        }

        public static void ClickAndEnterValueWithAction(By xpath, string value)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                Actions action = new Actions(Hooks.driver);
                action.Click(element).SendKeys(value).Build().Perform();
            }
            catch { throw; }
        }

        public static void ClickAndEnterValueWithActionAndClearEnabled(By xpath, string value)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                Actions action = new Actions(Hooks.driver);
                element.Clear();
                action.Click(element).SendKeys(value).Build().Perform();
            }
            catch { throw; }
        }

        public static void Quitdriver()
        {
            Hooks.driver.Quit();
        }

        #endregion
        

        public static IWebElement WaitForElementToBeDisplayed(By xpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Hooks.driver, TimeSpan.FromSeconds(timeoutValue));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(xpath));
                return element;
            }
            catch { throw; }
        }

        public static IWebElement WaitForElementToBeClickable(By xpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Hooks.driver, TimeSpan.FromSeconds(timeoutValue));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(xpath));
                return element;
            }
            catch { throw; }
        }
        public static IList<IWebElement> WaitForElementsToBeDisplayed(By xpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Hooks.driver, TimeSpan.FromSeconds(timeoutValue));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(xpath));
                return Hooks.driver.FindElements(xpath);
            }
            catch
            {
                return Hooks.driver.FindElements(xpath);
            }

        }
        public static IList<IWebElement> WaitForElementsToBeClickable(By xpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Hooks.driver, TimeSpan.FromSeconds(timeoutValue));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(xpath));
                return Hooks.driver.FindElements(xpath);
            }
            catch
            {
                return Hooks.driver.FindElements(xpath);
            }
        }
        public static void HighlightElement(IWebElement element)
        {
            try
            {
                IJavaScriptExecutor objIjse = (IJavaScriptExecutor)Hooks.driver;
                string strCss = @"arguments[0].style.cssText = ""background-color:yellow""";
                objIjse.ExecuteScript(strCss, new object[] { element });
                Thread.Sleep(1000);
                string strCss1 = @"arguments[0].style.cssText = ""background-color:none""";
                objIjse.ExecuteScript(strCss1, new object[] { element });
            }
            catch { throw; }
        }

        public static void ClickOperation(IList<IWebElement> objItems)
        {
            try
            {
                if (objItems.Count > 0)
                {
                    foreach (IWebElement element in objItems)
                    {
                        try
                        {
                            if (element.Displayed)
                            {
                                HighlightElement(element);
                                element.Click();
                                break;
                            }
                        }
                        catch { }
                    }
                }
                else
                {
                    Assert.Fail("Element not exists");
                    Quitdriver();
                }
            }
            catch { throw; }
        }

        public static void SelectDropdownByValue(By xpath, string value)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                SelectElement objElement = new SelectElement(element);
                objElement.SelectByValue(value);
            }
            catch { throw; }
        }
        public static void SelectDropdownByText(By xpath, string itemText)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                SelectElement objElement = new SelectElement(element);
                objElement.SelectByText(itemText);
            }
            catch { throw; }
        }

        public static bool IsDropdownValueSelected(By xpath, string itemText)
        {
            try
            {
                element = WaitForElementToBeDisplayed(xpath);
                SelectElement objElement = new SelectElement(element);
                if(objElement.SelectedOption.Text.Trim() == itemText)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { throw; }
        }

        public static void SelectDropdownByIndex(By xpath, string index)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                SelectElement objElement = new SelectElement(element);
                objElement.SelectByIndex(Convert.ToInt32(index));
            }
            catch { throw; }
        }

        public static void DoubleClickOnObject(By xpath)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                Actions action = new Actions(Hooks.driver);
                action.DoubleClick(element).Build().Perform();
            }
            catch { throw; }
        }

        public static void ClickOnObjectWithAction(By xpath)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                Actions action = new Actions(Hooks.driver);
                action.Click(element).Build().Perform();
            }
            catch { throw; }
        }

        public static void SelectFromSuggestionWithAction(By xpath1,By xpath2, string value)
        {
            try
            {
                Actions ac = new Actions(Hooks.driver);
                WebDriverWait wait = new WebDriverWait(Hooks.driver, TimeSpan.FromSeconds(timeoutValue));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(xpath1));
                ac.MoveToElement(element).Click().SendKeys(value).Build().Perform();
                IWebElement element2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(xpath2));
                Actions ac1 = new Actions(Hooks.driver);
                ac1.MoveToElement(element2).Click().Build().Perform();
            }
            catch { throw; }
        }

        public static void AcceptAlert()
        {
            try
            {
                alert = Hooks.driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch { throw; }          
        }

        public void DismissAlert()
        {
            try
            {
                alert = Hooks.driver.SwitchTo().Alert();
                alert.Dismiss();
            }
            catch { throw; }         
        }

        public bool VerifyAlertText(string expectedTextOnAlert)
        {
            alert = Hooks.driver.SwitchTo().Alert();
            if (alert.Text == expectedTextOnAlert)
                return true;
            else
                return false;
        }

        public static void SwitchWindow()
        {
            mainWindowHandle = Hooks.driver.CurrentWindowHandle;
            foreach (string handle in Hooks.driver.WindowHandles)
            {
                if (handle != mainWindowHandle)
                {
                    Hooks.driver.SwitchTo().Window(handle);
                    break;
                }
            }
        }

        public static void SwitchToParentWindow() => Hooks.driver.SwitchTo().Window(mainWindowHandle);

        public static void ScrollToElement(By xpath)
        {
            try {
                IWebElement elem = WaitForElementToBeDisplayed(xpath);
                ((IJavaScriptExecutor)Hooks.driver).ExecuteScript("arguments[0].scrollIntoView(true);", elem);
            }
            catch { throw; }
        }

        public static void ScrollDownThePage()
        {
            try
            {
                ((IJavaScriptExecutor)Hooks.driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            }
            catch { throw; }
        }

        public static void EnterValueWithClearEnabled(By xpath, string value)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
                element.SendKeys(value);             
            }
            catch { throw; }
        }
        public static bool IsEnabled(By xpath)
        {
            try
            {
                element = WaitForElementToBeDisplayed(xpath);
                HighlightElement(element);
                return element.Enabled;
            }
            catch { throw; }
        }
        public static bool IsReadOnly(By xpath)
        {
            try
            {
                element = WaitForElementToBeDisplayed(xpath);
                HighlightElement(element);
                return element.GetAttribute("readonly").Equals("true");
            }
            catch { throw; }
        }
        public static bool IsDisabled(By xpath)
        {
            try
            {
                element = WaitForElementToBeDisplayed(xpath);
                HighlightElement(element);
                return element.GetAttribute("disabled").Equals("true");
            }
            catch { throw; }
        }
        public static bool IsDropdownReadOnly(By xpath)
        {
            try
            {
                element = WaitForElementToBeDisplayed(xpath);
                HighlightElement(element);
                return element.GetAttribute("aria-readonly").Equals("true");
            }
            catch { throw; }
        }
        public static bool IsDropdownDisabled(By xpath)
        {
            try
            {
                element = WaitForElementToBeDisplayed(xpath);
                HighlightElement(element);
                return element.GetAttribute("aria-disabled").Equals("true");
            }
            catch { throw; }
        }
        public static bool IsSelected(By xpath)
        {
            try
            {
                element = WaitForElementToBeDisplayed(xpath);
                HighlightElement(element);
                return element.Selected;
            }
            catch { throw; }
        }
        public static string GetValueAttribute(By xpath)
        {
            try
            {
                element = WaitForElementToBeDisplayed(xpath);
                HighlightElement(element);
                return element.GetAttribute("value").ToString().Trim();
            }
            catch { throw; }
        }
        public static void VerifyFieldState(By xpath, string mode)
        {
            try
            {
                switch (mode)
                {
                    case "enabled":
                        Assert.IsTrue(IsEnabled(xpath));
                        break;
                    case "disabled":
                        Assert.IsFalse(IsEnabled(xpath));
                        break;
                    case "readonly":
                        Assert.IsTrue(IsReadOnly(xpath));
                        break;
                    case "displayed":
                        Assert.IsTrue(IsObjectDisplayed(xpath));
                        break;
                    case "not displayed":
                        Assert.IsFalse(IsObjectDisplayed(xpath));
                        break;
                    case "checked":
                        Assert.IsTrue(IsSelected(xpath));
                        break;
                    case "unchecked":
                        Assert.IsFalse(IsSelected(xpath));
                        break;
                    default:
                        break;
                }
            }
            catch { throw; }
        }
        public static void ClearText(By xpath)
        {
            try
            {
                element = WaitForElementToBeClickable(xpath);
                HighlightElement(element);
                element.Clear();
            }
            catch { throw; }
        }

        #endregion

    }
}
