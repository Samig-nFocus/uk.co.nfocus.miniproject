using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V113.DOM;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using uk.co.nfocus.miniproject.POMs;
using uk.co.nfocus.miniproject.Utilities;
using static uk.co.nfocus.miniproject.Utilities.Helpers;

namespace uk.co.nfocus.miniproject.Tests
{
    public class Tests : BaseTest
    {
        [Test, Category("Discount")]
        public void ApplyDiscount()
        {

            MyAccountPOM account = new MyAccountPOM(driver);
            account.Navigate();
            //Navigate to My Account Page

            LoginPOM login = new LoginPOM(driver);
            login.LogIn("abc19072023@gmail.com", "ecommerce123$");
            //LogIn method with values

            ShopPOM shop = new ShopPOM(driver);
            shop.AddCartItem();

            CouponPOM coupon = new CouponPOM(driver);
            coupon.Coupon("edgewords");
            //Coupon method with value

            Thread.Sleep(3000);
            //implicit wait for coupon to be fully applied.

            

            //check coupon takes off 15%

            IWebElement discount = driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-discount.coupon-edgewords > td > span"));
            //coupon value selector
            IWebElement subtotal = driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-subtotal > td > span > bdi"));
            //subtotal value selector

            decimal discountAmount = Decimal.Parse(discount.Text.Replace("£", ""));
            //convert the coupon value into decimal and remove £
            decimal subtotalAmount = Decimal.Parse(subtotal.Text.Replace("£", ""));
            //convert the subtotal value into decimal and remove £

            decimal expectedDiscount = subtotalAmount * 0.15m;
            //expected discount is 15% of subtotal

            Assert.AreEqual(expectedDiscount, discountAmount, "Coupon discount is not 15% of subtotal");
            // Assert that expected discount = displayed discount


            
            //check total is calculated correctly

            IWebElement total = driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.order-total > td > strong > span > bdi"));
            //total value selector
            IWebElement shipping = driver.FindElement(By.CssSelector("#shipping_method > li > label > span > bdi"));
            //shipping value selector

            decimal totalAmount = Decimal.Parse(total.Text.Replace("£", ""));
            //convert the total value into decimal and remove £
            decimal shippingAmount = Decimal.Parse(shipping.Text.Replace("£", ""));
            //convert the shipping value into decimal and remove £

            decimal expectedTotal = (subtotalAmount - discountAmount) + shippingAmount;
            //expected total = selected values added up

            Assert.AreEqual(expectedTotal, totalAmount, "Total is not correct");
            // Assert that expected total = displayed total


            IWebElement MyAccount = driver.FindElement(By.LinkText("My account"));
            MyAccount.Click();
            //click MyAccount

            IWebElement LogOut = WaitForElement(driver, By.LinkText("Logout"));
            LogOut.Click();
            //logout
        }

        [Test, Category("Order")]
        public void OrderCheck() {

            MyAccountPOM account = new MyAccountPOM(driver);
            account.Navigate();
            //Navigate to My Account Page

            LoginPOM login = new LoginPOM(driver);
            login.LogIn("abc19072023@gmail.com", "ecommerce123$");
            //LogIn method with values

            ShopPOM shop = new ShopPOM(driver);
            shop.AddCartItem();
            //add item and view cart

            IWebElement checkoutButton= driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > div > a"));
            //checkout button selector

            Actions scrollDown = new Actions(driver);
            //actions for scroll down
            scrollDown.MoveToElement(checkoutButton);
            //scroll down to checkoutButton
            scrollDown.Perform();
            //perform scroll down

            checkoutButton.Click();
            //click checkout button

            BillingPOM billing = new BillingPOM(driver);
            billing.OrderDetails("Agile", "Tester", "nFocus Testing", "e-Innovation Centre", "Telford", "TF2 9FT", "0370 242 6235", "abc19072023@gmail.com");
            //Fills in the following values

            Thread.Sleep(1000);
            //wait until payment selected

            billing.Order();
            //Places order

            Thread.Sleep(1000);
            //wait until order confirmation

            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\SamigSherchan\source\repos\uk.co.nfocus.miniproject\uk.co.nfocus.miniproject\Test Results\Order Number.png");
            //screenshot order

            IWebElement MyAccount = driver.FindElement(By.LinkText("My account"));
            MyAccount.Click();
            //click MyAccount

            IWebElement Orders = driver.FindElement(By.CssSelector("#post-7 > div > div > nav > ul > li.woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--orders > a"));
            Orders.Click();
            //click Orders

            IWebElement LogOut = driver.FindElement(By.CssSelector("#post-7 > div > div > nav > ul > li.woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--customer-logout > a"));
            LogOut.Click();
            //logout

        }
    }
}