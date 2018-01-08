using OpenQA.Selenium.Remote;
using System;
using TastefullySimple.IntegrationTests.Resources;

namespace TastefullySimple.IntegrationTests.PageObject.PageElement
{
    class Footer : BaseElement
    {

        public Footer(RemoteWebDriver webDriver) : base(webDriver)
        {

        }

        public void PressLinkInFooter(String selector)
        {
            GetElement(selector).Click();
        }
    }
}
