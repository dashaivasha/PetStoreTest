using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PetStore6.Driver
{
    public static class WebDriverExtensions
    {
        private static TimeSpan _defaultPollingInterval = TimeSpan.FromMilliseconds(2);
        private static TimeSpan _timeout = TimeSpan.FromSeconds(135);

        public static WebDriverWait GetWait(
            this IWebDriver driver,
            TimeSpan timeout = default,
            TimeSpan pollingInterval = default,
            Type[] exceeptionTypes = null)
        {
            var wait = new WebDriverWait(driver, timeout.Ticks == 0 ? _timeout : timeout)
            {
                PollingInterval = pollingInterval.Ticks == 0 ? _defaultPollingInterval : pollingInterval
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
