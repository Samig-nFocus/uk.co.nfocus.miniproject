using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace uk.co.nfocus.miniproject.POMs
{
    internal class LoginPOM
    {
        private IWebDriver _driver;
        //private driver for the LoginPOM only

        public LoginPOM(IWebDriver driver)
        {
            _driver = driver;
        }
        //private driver = public driver 
        //accessible for Tests

        private IWebElement _loginUsername => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("username")));
        //locates login username field

        private IWebElement _loginPassword => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("password")));
        //locates login password field

        private IWebElement _loginButton => _driver.FindElement(By.CssSelector("#customer_login > div.u-column1.col-1 > form > p:nth-child(3) > button"));
        //locates log in button

        public LoginPOM SetUsername(string username)
        {
            _loginUsername.Clear();
            _loginUsername.SendKeys(username);
            return this;
            //clears username field and sets username
        }

        public LoginPOM SetPassword(string password)
        {
            _loginPassword.Clear();
            _loginPassword.SendKeys(password);
            return this;
            //clears password field and sets password
        }

        public void Submit()
        {
            _loginButton.Click();
            //clicks Log In button
        }

        public void LogIn(string username, string password)
        {
            SetUsername(username);
            SetPassword(password);
            Submit();
            //method performs all
        }
    }
}
