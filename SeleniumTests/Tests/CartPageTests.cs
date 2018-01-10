using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TastefullySimple.IntegrationTests.Resources;
using TastefullySimple.IntegrationTests.PageObject;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using TastefullySimple.IntegrationTests.PageObject.PageElement;

namespace TastefullySimple.IntegrationTests.Tests
{
    class CartPageTests
    {

        [TestClass]
        public class Cart_Page_Tests
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

                _cart.getHeader().NavigateToShoppingCartPage(Selectors.HeaderShoppingCartButton);

                Assert.AreEqual(PageUrls.ShoppingCartUrl, _driver.Url);

            }

            [TestMethod]
            public void Shopping_Cart_Page_Has_Correct_Title()
            {

                _cart.getHeader().NavigateToShoppingCartPage(Selectors.HeaderShoppingCartButton);

                var shoppingCartPageHeaderText = _driver.FindElementByCssSelector(Selectors.ShoppingCartPageTitle).Text;
                Assert.AreEqual(ElementText.ShoppingCartPageHeaderText, shoppingCartPageHeaderText);

            }

            [TestMethod]
            public void Shopping_Cart_Page_Has_Correct_Breadcrumbs()
            {

                _cart.getHeader().NavigateToHeaderMenu(Selectors.HeaderShoppingCartButton);

                var shoppingCartPageBreadcrumbsText = _driver.FindElementByCssSelector(Selectors.Breadcrumbs).Text;
                Assert.AreEqual(Breadcrumbs.BreadcrumbShoppingCartPage, shoppingCartPageBreadcrumbsText);

            }

            [TestMethod]
            public void Shopping_Cart_Page_Items_Box_Has_No_Products_By_Default()
            {

                _cart.getHeader().NavigateToShoppingCartPage(Selectors.HeaderShoppingCartButton);

                var shoppingCartPageItemsBoxDefaultTitle = _driver.FindElementByCssSelector(Selectors.ShoppingCartPageCartItemsBox).Text;
                Assert.AreEqual(ElementText.ShoppingCartPageCartItemsBoxDefaultTitle, shoppingCartPageItemsBoxDefaultTitle);

            }

            //[TestMethod]
            public void Shopping_Cart_Page_Product_Added_With_Correct_Name_Price_Qty()
            {                

                _shopPage.getHeader().NavigateToShopPage();

                var productItemAddToCartButton = _driver.FindElementRandomly(Selectors.ShopPageProductAddToCartButton).Item1;

                var productItemName = productItemAddToCartButton.GetAttribute("data-title");

                var productPriceStrike = productItemAddToCartButton.GetCssValue("div.catalogItem-ft span");

                productItemAddToCartButton.Click();

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(5000));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(Selectors.NotificationMessageTitle)));

                _cart.getHeader().NavigateToShoppingCartPage(Selectors.HeaderShoppingCartButton);

                var productItemInShoppingCart = _driver.FindElementByCssSelector(Selectors.ShoppingCartPageProductNameInItemBox).Text;
                Assert.AreEqual(productItemName, productItemInShoppingCart);

            }
        }
    }
}

