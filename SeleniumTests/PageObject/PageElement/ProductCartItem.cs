using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using TastefullySimple.IntegrationTests.Resources;

namespace TastefullySimple.IntegrationTests.PageObject.PageElement
{
    public class ProductCartItem : ElementWithData
    {
        public ProductCartItem(IWebElement webElement, RemoteWebDriver webDriver) : base(webElement, webDriver,
            new Dictionary<string, By> {
                { "Name",By.CssSelector(Selectors.ShoppingCartPageCartItemName) },
                { "Price",By.CssSelector(".orderSummary-price") },
                { "PriceStrike",By.CssSelector(".orderSummary-price_orig") },
                { "PriceSale",By.CssSelector(".orderSummary-price_sale") }
            })
        {

        }
    }
}

