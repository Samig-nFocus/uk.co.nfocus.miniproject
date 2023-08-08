using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.miniproject.POMs
{
    internal class BillingPOM
    {
        private IWebDriver _driver;
        //private driver for the LoginPOM only

        public BillingPOM(IWebDriver driver)
        {
            _driver = driver;
        }
        //private driver = public driver 
        //accessible for Tests

        private IWebElement _nameField => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("billing_first_name")));
        //locates first name

        private IWebElement _lastnameField => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("billing_last_name")));
        //locates last name field

        private IWebElement _companyName => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("billing_company")));
        //locates company field

        private IWebElement _streetAddress => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("billing_address_1")));
        //locates street address field

        private IWebElement _city => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("billing_city")));
        //locates city field

        private IWebElement _postcode => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("billing_postcode")));
        //locates postcode field

        private IWebElement _phone => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("billing_phone")));
        //locates phone field

        private IWebElement _email => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("billing_email")));
        //locates phone field
        private IWebElement _paymentCheck => _driver.FindElement(By.CssSelector("#payment > ul > li.wc_payment_method.payment_method_cheque > label"));
        //checks payments

        private IWebElement _placeOrder => _driver.FindElement(By.CssSelector("#place_order"));
        //places Order


        //sets values for each field in billing
        public BillingPOM SetName(string name)
        {
            _nameField.Clear();
            _nameField.SendKeys(name);
            return this;
            
        }

        public BillingPOM SetLastname(string lastname)
        {
            _lastnameField.Clear();
            _lastnameField.SendKeys(lastname);
            return this;
            
        }

        public BillingPOM SetCompany(string company)
        {
            _companyName.Clear();
            _companyName.SendKeys(company);
            return this;

        }

        public BillingPOM SetAddress(string address)
        {
            _streetAddress.Clear();
            _streetAddress.SendKeys(address);
            return this;

        }
        public BillingPOM SetCity(string city)
        {
            _city.Clear();
            _city.SendKeys(city);
            return this;

        }

        public BillingPOM SetPostcode(string postcode)
        {
            _postcode.Clear();
            _postcode.SendKeys(postcode);
            return this;

        }

        public BillingPOM SetPhone(string phone)
        {
            _phone.Clear();
            _phone.SendKeys(phone);
            return this;

        }
        public BillingPOM SetEmail(string email)
        {
            _email.Clear();
            _email.SendKeys(email);
            return this;

        }

        public void CheckPayments()
        {
            _paymentCheck.Click();
            //click check payments option
        }


        public void PlaceOrder()
        {
            _placeOrder.Click();
            //click place order button
        }

        public void OrderDetails(string name, string lastname, string company, string address, string city, string postcode, string phone, string email)
        {
            SetName(name);
            SetLastname(lastname);
            SetCompany(company);
            SetAddress(address);
            SetCity(city);
            SetPostcode(postcode);
            SetPhone(phone);
            SetEmail(email);
            //method performs all
        }
        public void Order()
        {
            CheckPayments();
            PlaceOrder();
        }
    }
}
    