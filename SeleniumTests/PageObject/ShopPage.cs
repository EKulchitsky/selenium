using OpenQA.Selenium.Remote;
using System;

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

    }
}
