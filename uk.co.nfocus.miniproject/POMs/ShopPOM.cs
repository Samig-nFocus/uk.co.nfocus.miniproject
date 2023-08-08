using OpenQA.Selenium;
using static uk.co.nfocus.miniproject.Utilities.Helpers;

namespace uk.co.nfocus.miniproject.POMs
{
    internal class ShopPOM
    {
        private IWebDriver _driver;
        public ShopPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement _shopButton => _driver.FindElement(By.LinkText("Shop"));
        //locates log in button

        private IWebElement _closeMessage => _driver.FindElement(By.CssSelector("body > p > a"));
        //closes message blocking add to cart button

        private IWebElement _addItem => _driver.FindElement(By.CssSelector("#main > ul > li.product.type-product.post-28.status-publish.instock.product_cat-accessories.has-post-thumbnail.sale.shipping-taxable.purchasable.product-type-simple > a.button.product_type_simple.add_to_cart_button.ajax_add_to_cart"));
        //locates the add to cart button

        private IWebElement _viewCart => WaitForElement(_driver, By.LinkText("View cart"));
        //locates the view cart button

        public void ShopButton()
        {
            _shopButton.Click();
            //clicks shop button
        }

        public void CloseMessage()
        {
            _closeMessage.Click();
            //closes the message blocking add to cart buttons
        }

        public void AddCart()
        {
            _addItem.Click();
            //adds item to cart
        }

        public void ViewCart()
        {
            _viewCart.Click();
            //clicks view cart button
        }
        

        public void AddCartItem()
        {
            ShopButton();
            CloseMessage();
            AddCart();
            ViewCart();
        }
    }
}
