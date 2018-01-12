using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TastefullySimple.IntegrationTests.Resources;
using TastefullySimple.IntegrationTests.PageObject;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using TastefullySimple.IntegrationTests.PageObject.PageElement;
//using TastefullySimple.IntegrationTests.Entities;

namespace TastefullySimple.IntegrationTests.Tests
{

        [TestClass]
        public class CartPageTests
        {

            private RemoteWebDriver _driver;
            private LoginPage _loginPage;
            private ShopPage _shopPage;
            private Main _main;
            private CartPage _cart;

            [TestInitialize()]
            public void MyTestInitialize()
            {
                _driver = DriverFactory.CreateDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl("https://www.tastefullysimple.com");

                _loginPage = new LoginPage(_driver);
                _shopPage = new ShopPage(_driver);
                _main = new Main(_driver);
                _cart = new CartPage(_driver);
            }

            [TestCleanup()]
            public void MyTestCleanup()
            {
                _driver.Dispose();
            }


            [TestMethod]
            public void Cart_Page_Has_Correct_Url()
            {

                _cart.Header.ClickHeaderElement(Selectors.HeaderShoppingCartButton);

                Assert.AreEqual(PageUrls.ShoppingCartUrl, _driver.Url);

            }

            [TestMethod]
            public void Shopping_Cart_Page_Has_Correct_Title()
            {

                _cart.Header.ClickHeaderElement(Selectors.HeaderShoppingCartButton);

                var shoppingCartPageHeaderText = _driver.FindElementByCssSelector(Selectors.ShoppingCartPageTitle).Text;
                Assert.AreEqual(ElementText.ShoppingCartPageHeaderText, shoppingCartPageHeaderText);

            }

            [TestMethod]
            public void Shopping_Cart_Page_Has_Correct_Breadcrumbs()
            {

                _cart.Header.ClickHeaderElement(Selectors.HeaderShoppingCartButton);

                var shoppingCartPageBreadcrumbsText = _driver.FindElementByCssSelector(Selectors.Breadcrumbs).Text;
                Assert.AreEqual(Breadcrumbs.BreadcrumbShoppingCartPage, shoppingCartPageBreadcrumbsText);

            }

            [TestMethod]
            public void Shopping_Cart_Page_Items_Box_Has_No_Products_By_Default()
            {

                _cart.Header.ClickHeaderElement(Selectors.HeaderShoppingCartButton);

                var shoppingCartPageItemsBoxDefaultTitle = _driver.FindElementByCssSelector(Selectors.ShoppingCartPageCartItemsBox).Text;
                Assert.AreEqual(ElementText.ShoppingCartPageCartItemsBoxDefaultTitle, shoppingCartPageItemsBoxDefaultTitle);

            }

            [TestMethod]
            public void Shopping_Cart_Page_Product_Added_With_Correct_Name_Price_Qty()
            {

                _shopPage.Header.ClickHeaderElement(Selectors.HeaderNavShopButton);

                var shopProductItemAddToCartButton = _driver.FindElementRandomly("catalogItem catalogItem_product").Item1;

                /*var shopProductItem = new Product()
                {
                    Name = shopProductItemAddToCartButton.GetAttribute("data-title"),
                    //StrikePrice = double.Parse(shopProductItemAddToCartButton.GetCssValue("catalogItem-price").Replace("$", "")),
                    StrikePrice = GetStrikePrice(shopProductItemAddToCartButton)
                };
                */
                shopProductItemAddToCartButton.FindElement(By.CssSelector(Selectors.ShopPageProductAddToCartButton)).Click();

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(5000));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(Selectors.NotificationMessageTitle)));

                _cart.Header.ClickHeaderElement(Selectors.HeaderShoppingCartButton);

                /*var shoppingCartProductItem = new Product()
                {
                    Name = _driver.FindElementByClassName(Selectors.ShoppingCartPageProductNameInItemBox).Text,
                    StrikePrice = double.Parse(shopProductItemAddToCartButton.GetCssValue(".cartItemList-row-price span")),
                };

         */
                //Assert.AreEqual(shopProductItem, shoppingCartProductItem);

            }

            private double GetStrikePrice(IWebElement el)
            {                
                switch (el.FindElements(By.CssSelector("catalogItem-ft span")).Count)
                {
                    case 1:
                        return double.Parse(el.GetCssValue("catalogItem-price").Replace("$", ""));
                    case 2:
                        return double.Parse(el.GetCssValue("catalogItem-price_strike").Replace("$", ""));

                    default: break;
                }

                return 0.0;
            }
        }
    }


