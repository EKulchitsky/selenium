using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;

namespace TastefullySimple.IntegrationTests
{
    public enum Browser
    {
        Chrome,
        IE
    }

    public static class DriverFactory
    {
        public static RemoteWebDriver CreateDriver(Browser browser,string baseUrl,int timeoutSeconds)
        {
            RemoteWebDriver driver;
            switch (browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver();
                    break;
                case Browser.IE:
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    throw new ArgumentException();
            }
                        
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutSeconds);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);

            return driver;
        }

        public static RemoteWebDriver CreateDriver()
        {
            Browser browser = (Browser)Enum.Parse(typeof(Browser), ConfigurationManager.AppSettings["browser"]);
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            int timeoutSeconds = int.Parse(ConfigurationManager.AppSettings["timeoutSeconds"]);

            return CreateDriver(browser, baseUrl, timeoutSeconds);
        }

    }
}
