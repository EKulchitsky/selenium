using OpenQA.Selenium.Remote;
using TastefullySimple.IntegrationTests.PageObject.PageElement;

namespace TastefullySimple.IntegrationTests.PageObject
{
    public class LoginPage : BasePage
    {
        private Header h;

        public LoginPage(RemoteWebDriver driver) : base(driver)
        {
            h = new Header(driver);
        }
        
        public Header getHeader()
        {
            return h;
        }
    }
}