using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace uk.co.nfocus.miniproject.Utilities
{
    internal class Helpers
    {
        public static IWebElement WaitForElement(IWebDriver driver, By locator, int timeInSeconds = 3)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            IWebElement el = wait.Until(drv => drv.FindElement(locator));

            return el;
        }
    }
}