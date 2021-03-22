using TestFramework.Utility;

namespace TestFramework.PageObjects
{
    public class BrowserNavigation
    {
        #region SiteNavigation
        public static void NavigateToTheUrl(string urlName)
        {
            try
            {
                SeleniumOperations.NavigateToTheSite(Configurations.siteURL);
            }
            catch { throw; }
        }
        #endregion
    }
}
