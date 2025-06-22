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

            homePage.SearchForItem("Long printed dress with thin adjustable straps. V-neckline and wiring under the bust with ruffles at the bottom of the dress");

            homePage.ClickFirstItem();

            ProductPage productPage = new ProductPage(driver.Value);

            productPage.ChooseSize("M");

            productPage.AddToCart();

            productPage.VerifyAddedItem();
        }
    }
}
