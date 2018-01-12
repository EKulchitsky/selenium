using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TastefullySimple.IntegrationTests.PageObject.PageElement;

namespace TastefullySimple.IntegrationTests.PageObject
{
    public class ShopPage : BasePage
    {
        public ShopPage(RemoteWebDriver driver) : base(driver)
        {
            
        }

        public String GetProductName(string selector)
        {
            return driver.FindElementByCssSelector(selector).Text;
        }

        public ProductCatalogItem GetRandomProductCatalogItem() {
            return new ProductCatalogItem(driver.FindElementRandomly(By.CssSelector(".catalogItem_product:has(.btn-add-cart)")).Item1, driver);
        }
    }
}
