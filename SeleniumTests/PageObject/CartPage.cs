using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TastefullySimple.IntegrationTests.PageObject.PageElement;

namespace TastefullySimple.IntegrationTests.PageObject
{
    public class CartPage : BasePage
    {
        public CartPage(RemoteWebDriver driver) : base(driver)
        {

        }

        public ProductCartItem GetCartItem()
        {
            return new ProductCartItem(driver.FindElement(By.CssSelector(".cartItemList.js-checkForEmptyTable tr.cartItemList-row:first-child")), driver);
        }
    }
}
