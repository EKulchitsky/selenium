using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastefullySimple.IntegrationTests.Resources;

namespace TastefullySimple.IntegrationTests.PageObject.PageElement
{
    public class ProductCatalogItem : ElementWithData
    {
        public ProductCatalogItem(IWebElement webElement, RemoteWebDriver webDriver) : base(webElement, webDriver,
            new Dictionary<string, By> {
                { "Name",By.CssSelector(".hdg_5alt .js-catalogLink") },
                { "Price",By.ClassName("catalogItem-price") },
                { "PriceStrike",By.ClassName("catalogItem-price_strike") },
                { "PriceSale",By.ClassName("catalogItem-price_sale") }
            })
        {
        }

        public void ClickAddtoCartButton()
        {
            WebElement.FindElement(By.CssSelector(Selectors.ShopPageProductAddToCartButton)).Click();
        }

    }
}

