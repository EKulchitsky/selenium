using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TastefullySimple.IntegrationTests.Resources;
using TastefullySimple.IntegrationTests.PageObject;
using TastefullySimple.IntegrationTests.PageObject.PageElement;

namespace TastefullySimple.IntegrationTests.Tests
{

    [TestClass]
    public class MainPageTests
    {

        private RemoteWebDriver driver;
        private LoginPage LoginPage;
        private ShopPage ShopPage;
        private Footer Footer;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            driver = DriverFactory.CreateDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(PageUrls.TsoHomePage);

            LoginPage = new LoginPage(driver);
            Footer = new Footer(driver);
        }


        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Dispose();
        }


        [TestMethod]
        public void Check_Url_On_Main_Page()
        {
            Assert.AreEqual(PageUrls.TsoHomePage, driver.Url);
        }

    }
}