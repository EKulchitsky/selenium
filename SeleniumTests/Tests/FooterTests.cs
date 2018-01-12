using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TastefullySimple.IntegrationTests.Resources;
using TastefullySimple.IntegrationTests.PageObject;
using TastefullySimple.IntegrationTests.PageObject.PageElement;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium;

namespace TastefullySimple.IntegrationTests.Tests
{

    [TestClass]
    public class FooterTests
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
        public void Check_Connect_With_Us_Title_In_Footer()
        {
            var footerConnectWithUsTitle = driver.FindElementByCssSelector(Selectors.FooterConnectWithUsTitle).Text;

            Assert.AreEqual("connect with us", footerConnectWithUsTitle);            
        }

        [TestMethod]
        public void Check_Proud_Member_Title_In_Footer()
        {
            var footerProudMemberTitle = driver.FindElementByCssSelector(Selectors.FooterProudMemberTitle).Text;

            Assert.AreEqual("proud member", footerProudMemberTitle);
        }

        [TestMethod]
        public void Check_Facebook_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterFacebookLink);

            Assert.AreEqual(PageUrls.FacebookExternalLink, driver.ChangeContextWindow().Url);
        }

        [TestMethod]
        public void Check_Pinterest_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterPinterestLink);

            Assert.AreEqual(PageUrls.PinterestExternalLink, driver.ChangeContextWindow().Url);
        }

        [TestMethod]
        public void Check_Twitter_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterTwitterLink);

            Assert.AreEqual(PageUrls.TwitterExternalLink, driver.ChangeContextWindow().Url);
        }

        [TestMethod]
        public void Check_YouTube_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterYouTubeLink);

            Assert.AreEqual(PageUrls.YouTubeExternalLink, driver.ChangeContextWindow().Url);
        }

        [TestMethod]
        public void Check_Instagram_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterInstagramLink);

            Assert.AreEqual(PageUrls.InstagramExternalLink, driver.ChangeContextWindow().Url);
        }

        [TestMethod]
        public void Check_Bbb_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterBbbLink);

            Assert.AreEqual(PageUrls.BbbExternLlink, driver.ChangeContextWindow().Url);
        }

        [TestMethod]
        public void Check_Dsa_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterDsaLink);

            Assert.AreEqual(PageUrls.DsaExternalLink, driver.ChangeContextWindow().Url);
        }

        [TestMethod]
        public void Check_About_Us_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterAboutusLink);

            Assert.AreEqual(PageUrls.AboutUs, driver.Url);
        }

        [TestMethod]
        public void Check_Guarantee_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterGuaranteeLink);

            Assert.AreEqual(PageUrls.Guarantee, driver.Url);
        }

        [TestMethod]
        public void Check_Contact_Us_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterContactUsLink);

            Assert.AreEqual(PageUrls.ContactUs, driver.Url);
        }

        [TestMethod]
        public void Check_Employment_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterEmploymentLink);

            Assert.AreEqual(PageUrls.Employment, driver.Url);
        }

        [TestMethod]
        public void Check_Shipping_And_Delivery_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterShippingAndDeliveryLink);

            Assert.AreEqual(PageUrls.Shipping, driver.Url);
        }

        [TestMethod]
        public void Check_Terms_Of_Use_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterTermsOfUseLink);

            Assert.AreEqual(PageUrls.TermsOfUse, driver.Url);
        }

        [TestMethod]
        public void Check_Find_A_Consultant_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterFindConsultantLink);

            Assert.AreEqual(PageUrls.FindConsultant, driver.Url);
        }

        [TestMethod]
        public void Check_E_Catalog_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterECatalogFallWinter);
            driver.ChangeContextWindow();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(ExpectedConditions.UrlMatches(PageUrls.ECatalogExternalLink));

            Assert.AreEqual(PageUrls.ECatalogExternalLink, driver.Url);
        }

        [TestMethod]
        public void Check_Special_Offers_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterSpecialOffersLink);

            Assert.AreEqual(PageUrls.SpecialOffers, driver.Url);
        }

        [TestMethod]
        public void Check_Our_Products_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterOurProductsLink);

            Assert.AreEqual(PageUrls.OurProducts, driver.Url);
        }

        [TestMethod]
        public void Check_Meal_Kit_Delivery_Service_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterMealKitDeliveryService);

            Assert.AreEqual(PageUrls.MealKitDeliveryService, driver.Url);
        }

        [TestMethod]
        public void Check_Privacy_Policy_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterPrivacyPolicyLink);

            Assert.AreEqual(PageUrls.PrivacyPolicy, driver.Url);
        }

        [TestMethod]
        public void Check_Consultant_Login_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterConsultantLoginLink);

            Assert.AreEqual(PageUrls.ConsultantLoginExternalLink, driver.ChangeContextWindow().Url);
        }

        [TestMethod]
        public void Check_Consultant_Reactivation_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterConsultantReactivationLink);

            Assert.AreEqual(PageUrls.ConsultantReactivation, driver.Url);
        }

        [TestMethod]
        public void Check_Consultant_Spotlight_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterConsultantSpotlightLink);

            Assert.AreEqual(PageUrls.ConsultantSpotlight, driver.Url);
        }

        [TestMethod]
        public void Check_Dsa_Code_Of_Ethics_Link_In_Footer()
        {
            Footer.PressLinkInFooter(Selectors.FooterDsaCodeOfEthicslink);

            Assert.AreEqual(PageUrls.DsaCodeOfEthics, driver.Url);
        }

    }
}