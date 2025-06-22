using Shop.E2ETests.PageObjects;
using Shop.E2ETests.Utilities;

namespace Shop.E2ETests.Tests
{
    public class LoginTests : Base
    {
        [Theory]
        [InlineData("gpupulieva@gmail.com", "Graciela@1994")]
        public void LogIn_ShouldSucessfullyLogInUser(string username, string password)
        {
            HomePage homePage = new HomePage(driver.Value);

            homePage.ClickSignInNav();

            LoginPage loginPage = new LoginPage(driver.Value);

            loginPage.ClickEmailAddressField();

            loginPage.EnterEmail(username);

            loginPage.ClickPasswordField();

            loginPage.EnterPassword(password);

            loginPage.ClickSignIn();

            homePage.VerifyLoggedIn();
        }
    }
}
