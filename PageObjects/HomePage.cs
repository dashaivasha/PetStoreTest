using System;
using OpenQA.Selenium;
using System.IO;
using PetStore6.Driver;

namespace PetStore6.PageObjects
{
    public class HomePage : BasePage
    {
        private IWebElement GetByIdButton => Driver.FindElement(By.XPath("//div[contains(@id,'pet-get')]//button[contains(@aria-label,'petId')]"));
        private IWebElement PostPetButton => Driver.FindElement(By.XPath("//div[contains(@id,'pet-update')]//button"));
        private IWebElement PetTextArea => Driver.FindElement(By.XPath("//div[@class='model-example']//textarea"));
        private By TryItOutButton = By.XPath("//div[@class='try-out']/button");
        private By PetIdInput = By.XPath("//div[@class='table-container']//input[contains(@placeholder,'petId')]");
        private By ExecuteButton = By.XPath("//div[@class='execute-wrapper']/button");
        private By ResponseCode = By.XPath("//tr[@class='response']/td[@class='response-col_status']");

        public HomePage()
        {
        }

        public void PostPet()
        {
            Driver.GetWait().Until(d => PostPetButton.Enabled);
            PostPetButton.Click();
            WebDriverExtensions.FindElement(Driver, TryItOutButton, Data.WaitTime).Click();
            Driver.GetWait().Until(d => PetTextArea.Enabled);
            PetTextArea.Clear();
            PetTextArea.SendKeys(GetPetTxt());
            WebDriverExtensions.FindElement(Driver, ExecuteButton, Data.WaitTime).Click();
            PostPetButton.Click();
        }

        public void PressGetByIdButton()
        {
            Driver.GetWait().Until(d => GetByIdButton.Enabled);
            GetByIdButton.Click();      
        }

        public void EnterId(string id)
        {
            WebDriverExtensions.FindElement(Driver, TryItOutButton, Data.WaitTime).Click();
            WebDriverExtensions.FindElement(Driver, PetIdInput, Data.WaitTime).SendKeys(id);
        }

        public void Execute()
        {
            WebDriverExtensions.FindElement(Driver, ExecuteButton, Data.WaitTime).Click();
        }

        public int GetResponseCode()
        {
            var code = Convert.ToInt32(Driver.FindElement(ResponseCode).Text);

            return code;
        }

        private string GetPetTxt()
        {
            StreamReader sr = new StreamReader(Globals.PetPath);
            var petTxt = sr.ReadToEnd();
            sr.Close();

            return petTxt;
        }
    }
}
