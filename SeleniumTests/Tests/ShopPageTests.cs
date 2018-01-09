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
    class ShopPageTests
    {

        [TestClass]
        public class MainPageTests
        {

            private RemoteWebDriver _driver;
            private LoginPage _loginPage;
            private ShopPage _shopPage;
            private Main _main;

            [TestInitialize()]
            public void MyTestInitialize()
            {
                _driver = DriverFactory.CreateDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl("https://www.tastefullysimple.com");

                _loginPage = new LoginPage(_driver);
                _shopPage = new ShopPage(_driver);
                _main = new Main(_driver);
            }

            [TestCleanup()]
            public void MyTestCleanup()
            {
                _driver.Dispose();
            }

            [TestMethod]
            public void Select_30_Meal_Kits_In_Navigation_Menu()
            {

                _shopPage.getHeader().NavigateToHeaderMenu(Selectors.HeaderNavShopButton);

                _driver.FindElementById(Selectors.ShopPageNavMenu30MealKits).Click();
                Assert.AreEqual(PageUrls.Tso30MealKitsPage, _driver.Url);

            }

            [TestMethod]
            public void Breadcrumbs_Has_Correct_Text_After_30_Meal_Kits_Selected()
            {

                _shopPage.getHeader().NavigateToHeaderMenu(Selectors.HeaderNavShopButton);

                _driver.FindElementById(Selectors.ShopPageNavMenu30MealKits).Click();

                var breadcrumbsText = _driver.FindElementByCssSelector(Selectors.Breadcrumbs).Text;
                Assert.AreEqual(Breadcrumbs.Breadcrumb30MealKits, breadcrumbsText);

            }

            [TestMethod]
            public void Selected_Item_Has_Class_Selected()
            {

                _shopPage.getHeader().NavigateToHeaderMenu(Selectors.HeaderNavShopButton);

                _driver.FindElementById(Selectors.ShopPageNavMenu30MealKits).Click();

                var selectedMenuItemHasClassSelected = _driver.FindElementByClassName(Selectors.ShopPageSearchFiltersSelected);
                Assert.IsNotNull(selectedMenuItemHasClassSelected);
            }

            [TestMethod]
            public void Selected_Menu_Item_Has_Correct_Text()
            {

                _shopPage.getHeader().NavigateToHeaderMenu(Selectors.HeaderNavShopButton);

                _driver.FindElementById(Selectors.ShopPageNavMenu30MealKits).Click();

                var selectedItemText = _driver.FindElementByClassName(Selectors.ShopPageSearchFiltersSelected).Text;
                Assert.AreEqual(selectedItemText, ElementText.NavMenu30MealKitsText);

            }


            [TestMethod]
            public void User_Is_Able_To_Add_A_Product_To_Cart()
            {
                HomePage HomePage = _loginPage.getHeader().LogIn();

                _shopPage.getHeader().NavigateToShopPage();

                var productItemAddToCartButton = _driver.FindElementRandomly(Selectors.ShopPageProductAddToCartButton).Item1;

                var productItemName = productItemAddToCartButton.GetAttribute("data-title");

                productItemAddToCartButton.Click();

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(5000));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(Selectors.NotificationMessageTitle)));

                var notificationMessageTitle = _driver.FindElementByCssSelector(Selectors.NotificationMessageTitle).Text;

                var notificationProductTitle = _driver.FindElementByCssSelector(Selectors.NotificationMessageProductTitle).Text;

                Assert.AreEqual(ElementText.AddedToCartNotificationMessageText, notificationMessageTitle);

                Assert.AreEqual(productItemName, notificationProductTitle);

            }
        }
    }
}

