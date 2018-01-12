using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastefullySimple.IntegrationTests.PageObject.PageElement
{
    //TO-DO: MOve it to separate file. 
    public class ShortImplicitWait : IDisposable
    {
        private readonly IWebDriver _webDriver;
        public ShortImplicitWait(RemoteWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 0, 0, 200);
        }
        public void Dispose()
        {
            _webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 20);

        }
    }

    public class ElementWithData : BaseElement
    {
        private Dictionary<string, By> _dataSelectors;

        public Dictionary<string, string> Data { get; }

        public ElementWithData(IWebElement webElement, RemoteWebDriver webDriver, Dictionary<string, By> dataSelectors)
            : base(webElement, webDriver)
        {
            Data = new Dictionary<string, string>();
            _dataSelectors = dataSelectors;

            using (new ShortImplicitWait(webDriver))
            {
                foreach (var dataSelector in _dataSelectors)
                {                    
                    var elements = webElement.FindElements(dataSelector.Value);
                    if (elements.Any())
                    {
                        Data[dataSelector.Key] = elements.First().Text;
                    }                 
                }
            }            

        }

        public bool IsDataEquals(ElementWithData element)
        {
            if (Data.Count != element.Data.Count)
            {
                return false;
            }

            foreach (var item in Data)
            {
                if (!element.Data.ContainsKey(item.Key))
                {
                    return false;
                }

                if (element.Data[item.Key] != item.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }

}
