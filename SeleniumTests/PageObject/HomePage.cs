using System;
using OpenQA.Selenium.Remote;
using TastefullySimple.IntegrationTests.Resources;

namespace TastefullySimple.IntegrationTests.PageObject
{
    public class HomePage : BasePage
    {
        public HomePage(RemoteWebDriver driver) : base(driver)
        {

        }

        public String GetAccountName()
        {
            return driver.FindElementByCssSelector(Selectors.HeaderMyAccountLinkName).Text;
        }

    }
}

