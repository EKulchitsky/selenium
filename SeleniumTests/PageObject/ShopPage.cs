using OpenQA.Selenium.Remote;
using TastefullySimple.IntegrationTests.PageObject.PageElement;
using System;
using TastefullySimple.IntegrationTests.Resources;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace TastefullySimple.IntegrationTests.PageObject
{
    public class ShopPage : BasePage
    {
        private Header h;

        public Header getHeader()
        {
            return h;
        }

        public ShopPage(RemoteWebDriver driver) : base(driver)
        {
            h = new Header(driver);
        }

        public String GetProductName(string selector)
        {
            return driver.FindElementByCssSelector(selector).Text;
        }

    }
}
