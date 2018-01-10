using OpenQA.Selenium.Remote;
using TastefullySimple.IntegrationTests.PageObject.PageElement;

namespace TastefullySimple.IntegrationTests.PageObject
{
    public class BasePage
    {
        protected RemoteWebDriver driver;

        public BasePage(RemoteWebDriver driver)
        {
            this.driver = driver;

            header = new Header(driver);
        }

        protected Header header;

        public Header getHeader()
        {
            return header;
        }

    }
}
