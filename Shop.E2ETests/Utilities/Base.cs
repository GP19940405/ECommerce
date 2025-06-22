using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace Shop.E2ETests.Utilities
{
    public class Base : IDisposable
    {
        public ThreadLocal<IWebDriver> driver = new();
        protected WebDriverWait wait;

        public Base()
        {
            var settings = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            string browserName = settings["browser"];
            string baseUrl = settings["baseUrl"];


            if (string.IsNullOrEmpty(browserName))
            {
                throw new ArgumentNullException("Browser name is not specified in App.config");
            }

            InitBrowser(browserName);

            if (driver.Value != null)
            {
                driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                driver.Value.Manage().Window.Maximize();
                driver.Value.Navigate().GoToUrl(baseUrl);

                wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(20));
            }
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    var chromeDriverService = ChromeDriverService.CreateDefaultService();
                    driver.Value = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromMinutes(3));
                    break;
                case "Edge":
                    var edgeOptions = new EdgeOptions();
                    var edgeDriverService = EdgeDriverService.CreateDefaultService();
                    driver.Value = new EdgeDriver(edgeDriverService, edgeOptions, TimeSpan.FromMinutes(3));
                    break;
                default:
                    throw new ArgumentException("Browser name is not recognized.");
            }

            if (driver.Value == null)
            {
                throw new InvalidOperationException("WebDriver initialization failed.");
            }
        }

        public void Dispose()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
                driver.Value = null;
            }
        }
    }
}