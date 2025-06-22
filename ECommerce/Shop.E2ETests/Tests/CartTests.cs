using Shop.E2ETests.PageObjects;
using Shop.E2ETests.Utilities;

namespace Shop.E2ETests.Tests
{
    public class CartTests : Base
    {
        [Fact]
        public void AddItemToCart_ShouldSuccessfullyAddItem()
        {
            HomePage homePage = new HomePage(driver.Value);

            homePage.ClickSearchField();

            homePage.SearchForItem("Short sleeved blouse with feminine draped sleeve detail");

            homePage.ClickFirstItem();

            ProductPage productPage = new ProductPage(driver.Value);

            productPage.ChooseSize("M");

            productPage.ChooseWhite();

            productPage.AddToCart();

            productPage.VerifyAddedItem();
        }
    }
}
