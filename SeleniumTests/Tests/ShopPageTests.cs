using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TastefullySimple.IntegrationTests.Resources;
using TastefullySimple.IntegrationTests.PageObject;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace TastefullySimple.IntegrationTests.Tests
{
    class ShopPageTests
    {

        [TestClass]
        public class MainPageTests
        {

            private RemoteWebDriver driver;
            private LoginPage LoginPage;
            private ShopPage ShopPage;

            [TestInitialize()]
            public void MyTestInitialize()
            {
                driver = DriverFactory.CreateDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.tastefullysimple.com");

                LoginPage = new LoginPage(driver);
                ShopPage = new ShopPage(driver);
            }

            [TestCleanup()]
            public void MyTestCleanup()
            {
                driver.Dispose();
            }

            [TestMethod]
            public void User_Can_Open_30_Meal_Kits_In_Navigation_Menu()
            {

                ShopPage shopPage = ShopPage.getHeader().NavigateToShopPage();

                driver.FindElementById(Selectors.ShopPageNavMenu30MealKits).Click();          
                Assert.AreEqual(PageUrls.Tso30MealKitsPage, driver.Url);

                driver.FindElementByCssSelector(Selectors.ShopPageProductViewDetailsButton).Click();
                Assert.AreEqual(PageUrls._30MealKitFallDetailedPage, driver.Url);

            }


            // [TestMethod]
            public void User_is_able_to_add_a_Product_to_Cart()
            {
                HomePage HomePage = LoginPage.getHeader().LogIn();
                ShopPage shopPage = ShopPage.getHeader().NavigateToShopPage();

                var productItem = driver.FindElementRandomly(Selectors.ShopPageProductAddToCartButton).Item1;

                var productItemName = productItem.GetAttribute("data-title");

                productItem.Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(Selectors.NotificationTitle)));

                var notificationTitle = driver.FindElementByCssSelector(Selectors.NotificationTitle).Text;

                var notificationProductTitle = driver.FindElementByCssSelector(Selectors.NotificationProductTitle).Text;

                Assert.AreEqual("added to your cart:", notificationTitle);

                Assert.AreEqual(productItemName, notificationProductTitle);

            }
        }
    }
}

