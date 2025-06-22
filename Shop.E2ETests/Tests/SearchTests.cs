using Shop.E2ETests.PageObjects;
using Shop.E2ETests.Utilities;

namespace Shop.E2ETests.Tests
{
    public class SearchTests : Base
    {
        [Theory]
        [InlineData("V-neckline with elastic under the bust lining")]
        [InlineData("Short sleeved blouse with feminine draped sleeve detail")]
        public void SearchItem_ShouldFindItem(string item)
        {
            HomePage homePage = new HomePage(driver.Value);

            homePage.ClickSearchField();

            homePage.SearchForItem(item);

            homePage.ClickFirstItem();

            ProductPage productPage = new ProductPage(driver.Value);

            productPage.VerifySearchedItem(item);
        }
    }
}
