using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.miniproject.POMs
{
    internal class MyAccountPOM
    {
        private IWebDriver _driver;

        public MyAccountPOM(IWebDriver driver)
        {
            _driver = driver;
            //private driver = public driver 
            //accessible for Tests
        }

        public void Navigate()
        {
            _driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
            //navigates to My Account Page
        }
    }
}
