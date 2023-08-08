using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.miniproject.POMs
{
    internal class CouponPOM
    {
        private IWebDriver _driver;

        public CouponPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement _enterCoupon => _driver.FindElement(By.CssSelector("#coupon_code"));
        private IWebElement _applyCoupon => _driver.FindElement(By.CssSelector("#post-5 > div > div > form > table > tbody > tr:nth-child(2) > td > div > button"));

        public CouponPOM SetCoupon(string couponCode)
        {
            _enterCoupon.Click();
            _enterCoupon.Clear();
            _enterCoupon.SendKeys(couponCode);
            return this;
            //clears coupon field and enters coupon
        }

        public void ApplyCoupon()
        {
            _applyCoupon.Click();
            //click apply coupon button
        }

        public void Coupon(string couponCode)
        {
            SetCoupon(couponCode);
            ApplyCoupon();
        }
    }
}
