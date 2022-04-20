using System;
using PetStore6.UITests.UITestData.WebDriver;
using OpenQA.Selenium;
using System.IO;

namespace PetStore6.UITests.PageObjects
{
    public class HomePage : BasePage
    {
        private IWebElement GetByIdButton => driver.FindElement(By.XPath("//div[contains(@id,'pet-get')]//button[contains(@aria-label,'petId')]"));
        private IWebElement PostPetButton => driver.FindElement(By.XPath("//div[contains(@id,'pet-update')]//button"));
        private IWebElement PetTextArea => driver.FindElement(By.XPath("//div[@class='model-example']//textarea"));
        private By TryItOutButton = By.XPath("//div[@class='try-out']/button");
        private By PetIdInput = By.XPath("//div[@class='table-container']//input[contains(@placeholder,'petId')]");
        private By ExecuteButton = By.XPath("//div[@class='execute-wrapper']/button");
        private By ResponseCode = By.XPath("//td[@class='response-col_status']");

        public HomePage()
        {
        }

        public void PostPet()
        {
            driver.GetWait().Until(d => PostPetButton.Enabled);
            PostPetButton.Click();
            WebDriverExtensions.FindElement(driver, TryItOutButton, Data.WaitTime).Click();
            driver.GetWait().Until(d => PetTextArea.Enabled);
            PetTextArea.Clear();
            PetTextArea.SendKeys(GetPetTxt());
            WebDriverExtensions.FindElement(driver, ExecuteButton, Data.WaitTime).Click();
            PostPetButton.Click();
        }

        public void PressGetByIdButton()
        {
            driver.GetWait().Until(d => GetByIdButton.Enabled);
            GetByIdButton.Click();      
        }

        public void EnterId(string id)
        {
            WebDriverExtensions.FindElement(driver, TryItOutButton, Data.WaitTime).Click();
            WebDriverExtensions.FindElement(driver, PetIdInput, Data.WaitTime).SendKeys(id);
        }

        public void Execute()
        {
            WebDriverExtensions.FindElement(driver, ExecuteButton, Data.WaitTime).Click();
        }

        public int GetResponseCode()
        {
            var code = Convert.ToInt32(driver.FindElement(ResponseCode).Text);
            return code;
        }

        private String GetPetTxt()
        {
            StreamReader sr = new StreamReader(Globals.PetPath);
            var petTxt = sr.ReadToEnd();
            sr.Close();

            return petTxt;
        }
    }
}
