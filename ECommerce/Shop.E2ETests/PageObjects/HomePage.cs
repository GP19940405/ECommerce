using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Shop.E2ETests.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly IWebElement searchField;
        private readonly IWebElement logInNavBar;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            searchField = driver.FindElement(By.CssSelector("#search_query_top"));
            logInNavBar = driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a"));
        }

        public void ClickSignInNav()
        {
            logInNavBar.Click();
        }

        public void ClickSearchField()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchField));
            searchField.Click();
        }

        public void ClickFirstItem()
        {
            IWebElement firstItem = driver.FindElement(By.CssSelector("div.ac_results > ul > li"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(firstItem));
            firstItem.Click();
        }

        public void SearchForItem(string item)
        {
            searchField.SendKeys(item);
        }

        public void VerifyLoggedIn()
        {
            var loggedUserInitials = driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div:nth-child(1) > a > span")).Displayed;
            Assert.True(loggedUserInitials);
        }
    }
}