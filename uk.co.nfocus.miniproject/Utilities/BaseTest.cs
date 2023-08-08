using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.miniproject.Utilities
{
    public class BaseTest
    {
        protected static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            //Chrome browser
            driver.Manage().Window.Maximize();
            //maximize browser
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
            //closes browser
        }

    }
}

