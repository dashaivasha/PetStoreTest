using System;
using OpenQA.Selenium;
using System.IO;
using PetStore6.Driver;
using PetStore6.Constants;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace PetStore6.PageObjects
{
    public class HomePage : BasePage
    {
        private IWebElement GetByIdButton => Driver.FindElement(By.XPath("//div[contains(@id,'pet-get')]//button[contains(@aria-label,'petId')]"));
        private By DeleteByIdButton = By.XPath("//div[contains(@id,'pet-delete')]//button[contains(@aria-label,'petId')]");    
        private IWebElement PostPetButton => Driver.FindElement(By.XPath("//div[contains(@id,'pet-update')]//button"));
        private IWebElement PetTextArea => Driver.FindElement(By.XPath("//div[@class='model-example']//textarea"));
        private By TryItOutButton = By.XPath("//div[@class='try-out']/button");
        private By TryItOutButtonDelete = By.XPath("//div[contains(@class,'delete')]//div[@class='try-out']/button");
        private By PetIdInput = By.XPath("//div[@class='table-container']//input[contains(@placeholder,'petId')]");
        private By PetIdInputDelete = By.XPath("//div[contains(@class,'delete')]//input[contains(@placeholder,'petId')]");
        private By Api_keyInput = By.XPath("//div[contains(@class,'delete')]//tr[contains(@data-param-name,api_key)]//input[1]");
        private By ExecuteButtonDelete = By.XPath("//div[contains(@class,'delete')]//div[@class='execute-wrapper']/button");
        private By ExecuteButton = By.XPath("//div[@class='execute-wrapper']/button");
        private By ResponseCode = By.XPath("//tr[@class='response']/td[@class='response-col_status']");
        private By ResponseCodeDelete = By.XPath("//div[contains(@class,'delete')]//tr[@class='response']/td[@class='response-col_status']");

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

        public void PressDeleteByIdButton()
        {
            WebDriverExtensions.FindElement(Driver, DeleteByIdButton, Data.WaitTime).Click();
        }

        public void EnterId(string id)
        {
            WebDriverExtensions.FindElement(Driver, TryItOutButton, Data.WaitTime).Click();
            WebDriverExtensions.FindElement(Driver, PetIdInput, Data.WaitTime).SendKeys(id);
        }

        public void EnterIdForDelete(string id)
        {
            WebDriverExtensions.FindElement(Driver, TryItOutButtonDelete, Data.WaitTime).Click();
            WebDriverExtensions.FindElement(Driver, PetIdInputDelete, Data.WaitTime).SendKeys(id);
        }

        public void EnterApi_key(string key)
        {
            WebDriverExtensions.FindElement(Driver, Api_keyInput, Data.WaitTime).SendKeys(key);
        }

        public void Execute()
        {
            WebDriverExtensions.FindElement(Driver, ExecuteButton, Data.WaitTime).Click();
        }

        public void ExecuteDelete()
        {
            WebDriverExtensions.FindElement(Driver, ExecuteButtonDelete, Data.WaitTime).Click();
        }

        public int GetResponseCode()
        {
            WebDriverExtensions.FindElement(Driver, ResponseCode, Data.WaitTime);
            var strCode = Driver.FindElement(ResponseCode).Text;
            var resultString = Regex.Match(strCode, @"\d+").Value;
            var code = Convert.ToInt32(Driver.FindElement(ResponseCode).Text);

            return code;
        }

        public int GetDeleteResponseCode()
        {
            WebDriverExtensions.FindElement(Driver, ResponseCodeDelete, Data.WaitTime);
            var strCode = Driver.FindElement(ResponseCodeDelete).Text;
            var resultString = Regex.Match(strCode, @"\d+").Value;
            var code = Convert.ToInt32(resultString);

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
