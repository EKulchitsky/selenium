using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Linq;


namespace TastefullySimple.IntegrationTests
{
    public static class DriverExtensions
    {
        public static Tuple<IWebElement,int> FindElementRandomly(this RemoteWebDriver driver,By containerSelector)
        {
            var elements = driver.FindElements(containerSelector).ToList();

            int index = new Random().Next(0, elements.Count);

            return new Tuple<IWebElement, int>(elements[index], index);
        }

        public static Tuple<IWebElement, int> FindElementRandomly(this RemoteWebDriver driver, By containerSelector,Func<IWebElement,bool> predicate)
        {
            var elements = driver.FindElements(containerSelector)
                                    .Where(predicate)
                                    .ToList();

            int index = new Random().Next(0, elements.Count);

            return new Tuple<IWebElement, int>(elements[index], index);
        }

        public static RemoteWebDriver ChangeContextWindow(this RemoteWebDriver driver)
        {
            var handles = driver.WindowHandles.ToList<string>();
            driver.SwitchTo().Window(handles.Last());

            return driver;
        }
    }
}
