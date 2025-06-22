using OpenQA.Selenium;

namespace Shop.E2ETests.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly IWebElement emailField;
        private readonly IWebElement passwordField;
        private readonly IWebElement singIn;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            emailField = driver.FindElement(By.CssSelector("#email"));
            passwordField = driver.FindElement(By.CssSelector("#passwd"));
            singIn = driver.FindElement(By.CssSelector("#SubmitLogin > span"));
        }

        public void ClickEmailAddressField()
        {
            emailField.Click();
        }

        public void ClickPasswordField()
        {
            passwordField.Click();
        }

        public void EnterEmail(string username)
        {
            emailField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            passwordField.SendKeys(password);
        }

        public void ClickSignIn()
        {
            singIn.Click();
        }
    }
}