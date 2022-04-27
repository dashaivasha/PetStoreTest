using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Opera;
using PetStore6.Constants.Enums;
using PetStore6.TestData;

namespace PetStore6.Driver
{
    public class DriverFactory
    {
        private static IWebDriver? _webDriver;
        public static TestDetails Data = JsonManager.GetTestData();

        public static IWebDriver Driver
        {
            get
            {
                if (_webDriver == null)
                    throw new NullReferenceException("The WebDriver instance was not initialize. You should call the metod InitilizerDriver()");

                return _webDriver;
            }
            private set
            {
                _webDriver = value;
            }
        }

        public static void QuitDriver()
        {
            _webDriver?.Quit();
            _webDriver?.Dispose();
            _webDriver = null;
        }

        public static void InitalizerDriver()
        {
            var browser = Data.Browser;
            Enum.TryParse(browser, out BrowserNameEnum browserNameEnum);

            switch (browserNameEnum)
            {
                case BrowserNameEnum.Chrome:
                    if (_webDriver == null)
                    {
                        _webDriver = new ChromeDriver(Globals.DriverPath);
                    }
                    break;
                case BrowserNameEnum.Opera:
                    if (_webDriver == null)
                    {
                        _webDriver = new OperaDriver();
                    }
                    break;
            }
        }
    }
}
