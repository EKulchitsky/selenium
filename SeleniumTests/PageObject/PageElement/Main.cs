using OpenQA.Selenium.Remote;
using System;
using TastefullySimple.IntegrationTests.Resources;

namespace TastefullySimple.IntegrationTests.PageObject.PageElement
{
    class Main : BaseElement
    {

        public Main(RemoteWebDriver webDriver) : base(webDriver)
        {

        }


        public string GetBreadcrumbText(String selector)
        {
            var BreadcrumbText = Driver.FindElementByCssSelector(selector).Text;

            return BreadcrumbText;
        }
    }
}
