using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PetStore6.UITests.UITestData.WebDriver
{
    public static class WebDriverExtensions
    {
        public static TimeSpan DefaultPollingInterval = TimeSpan.FromMilliseconds(2);
        public static TimeSpan Timeout = TimeSpan.FromSeconds(135);

        public static WebDriverWait GetWait(
            this IWebDriver driver,
            TimeSpan timeout = default,
            TimeSpan pollingInterval = default,
            Type[] exceeptionTypes = null)
        {
            var wait = new WebDriverWait(driver, timeout.Ticks == 0 ? Timeout : timeout)
            {
                PollingInterval = pollingInterval.Ticks == 0 ? DefaultPollingInterval : pollingInterval
            };

            wait.IgnoreExceptionTypes(exceeptionTypes ?? new[] { typeof(StaleElementReferenceException) });

            return wait;
        }

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }

            return driver.FindElement(by);
        }
    }
}
