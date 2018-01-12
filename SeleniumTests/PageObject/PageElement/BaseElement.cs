using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TastefullySimple.IntegrationTests.PageObject.PageElement
{
    public abstract class BaseElement
    {
        private RemoteWebDriver _driver;
        private string _selector;
        private IWebElement _webElement;

        public RemoteWebDriver Driver => _driver;
        public string Selector => _selector;
        public IWebElement WebElement => _webElement;

        protected BaseElement(RemoteWebDriver webDriver)
        {
            _driver = webDriver;
        }

        protected BaseElement(string selector, RemoteWebDriver webDriver) : this(webDriver)
        {            
            _selector = selector;
        }

        protected BaseElement(IWebElement webElement, RemoteWebDriver webDriver) : this(webDriver)
        {
            _webElement = webElement;            
        }

        public IWebElement GetElement(string selector)
        {
            return Driver.FindElementByCssSelector(selector);
        }
    }
}
