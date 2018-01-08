using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TastefullySimple.IntegrationTests.PageObject.PageElement
{
    public abstract class BaseElement
    {
        private RemoteWebDriver _driver;
        private string _selector;

        public RemoteWebDriver Driver => _driver;
        public string Selector => _selector;

        protected BaseElement(RemoteWebDriver webDriver)
        {
            _driver = webDriver;
        }

        protected BaseElement(string selector, RemoteWebDriver webDriver)
        {
            _driver = webDriver;
            _selector = selector;
        }

        public IWebElement GetElement(string selector)
        {
            return Driver.FindElementByCssSelector(selector);
        }
    }
}
