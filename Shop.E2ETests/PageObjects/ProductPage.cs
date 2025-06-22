using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Shop.E2ETests.PageObjects
{
    public class ProductPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly IWebElement size;
        private readonly IWebElement addToCard;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            size = driver.FindElement(By.CssSelector("#group_1"));
            addToCard = driver.FindElement(By.CssSelector("#add_to_cart"));
        }

        public void ChooseSize(string s)
        {
            size.Click();

            var itemSize = driver.FindElement(By.CssSelector($"[title = \"{s}\"]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(itemSize));
            itemSize.Click();
        }

        public void AddToCart()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addToCard));
            addToCard.Click();
        }

        public void VerifySearchedItem(string item)
        {
            var actualItemName = driver.FindElement(By.CssSelector("#short_description_content > p")).Text;
            Assert.Contains(item, actualItemName);
        }

        public void VerifyAddedItem()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_product.col-xs-12.col-md-6 > h2")));
            IWebElement successMessage = driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_product.col-xs-12.col-md-6 > h2"));
            Assert.Equal("Product successfully added to your shopping cart", successMessage.Text);
        }
    }
}