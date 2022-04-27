using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PetStore6.Driver;
using System.IO;
using System.Text.RegularExpressions;

namespace PetStore6.PageObjects
{
    public class HomePage : BasePage
    {
        private IWebElement GetByIdButton => Driver.FindElement(By.XPath("//div[contains(@id,'pet-get')]//button[contains(@aria-label,'petId')]"));
        private IWebElement PostPetButton => Driver.FindElement(By.XPath("//div[contains(@id,'pet-update')]//button"));
        private IWebElement PetTextArea => Driver.FindElement(By.XPath("//div[@class='model-example']//textarea"));
        private IWebElement OrderTextArea => Driver.FindElement(By.XPath("//div[contains(@id,'store-placeOrder')]//textarea"));
        private By DeleteByIdButton = By.XPath("//div[contains(@class,'delete')]//button[contains(@aria-label,'pet')]");
        private By PostOrderButton = By.XPath("//div[contains(@id,'store-placeOrder')]//button[contains(@aria-label,'post')]");
        private By FindByStatusButton = By.XPath("//div[contains(@id,'findPetsByStatus')]//button[contains(@aria-label,'find')]");
        private By TryItOutButton = By.XPath("//div[contains(@class,'get')]//div[@class='try-out']/button");
        private By TryItOutPostOrderButton = By.XPath("//div[contains(@id,'store-placeOrder')]//div[@class='try-out']/button");
        private By TryItOutButtonStatus = By.XPath("//div[contains(@id,'findPetsByStatus')]//div[@class='try-out']/button");
        private By TryItOutButtonDelete = By.XPath("//div[contains(@class,'delete')]//div[@class='try-out']/button");
        private By PetIdInput = By.XPath("//div[contains(@class,'get')]//div[@class='table-container']//input[contains(@placeholder,'petId')]");
        private By PetIdInputDelete = By.XPath("//div[contains(@class,'delete')]//input[contains(@placeholder,'petId')]");
        private By StatusSelect = By.XPath("//div[contains(@id,'findPetsByStatus')]//tr//select");
        private By Api_keyInput = By.XPath("//div[contains(@class,'delete')]//tr[contains(@data-param-name,api_key)]//input[1]");
        private By ResponseCode = By.XPath("//div[contains(@class,'get')]//tr[@class='response']/td[@class='response-col_status']");
        private By ResponseCodeOrder = By.XPath("//div[contains(@id,'store-placeOrder')]//tr[@class='response']/td[@class='response-col_status']");
        private By ResponseCodeDelete = By.XPath("//div[contains(@class,'delete')]//tr[@class='response']/td[@class='response-col_status']");
        private By ResponseCodeStatus = By.XPath("//div[contains(@id,'findPetsByStatus')]//tr[@class='response']/td[@class='response-col_status']");
        private By ExecuteButton = By.XPath("//div[contains(@class,'get')]//div[@class='execute-wrapper']/button");
        private By ExecuteButtonOrder = By.XPath("//div[contains(@id,'store-placeOrder')]//div[@class='execute-wrapper']/button");
        private By ExecuteButtonStatus = By.XPath("//div[contains(@id,'findPetsByStatus')]//div[@class='execute-wrapper']/button");
        private By ExecuteButtonDelete = By.XPath("//div[contains(@class,'delete')]//div[@class='execute-wrapper']/button");
        private By ResponseData = By.XPath("//div[contains(@id,'findPetsByStatus')]//div[contains(@class,'code') and contains (.//div, 'Download') ]//pre");

        public HomePage()
        {
        }

        public void PostPet()
        {
            Driver.GetWait().Until(d => PostPetButton.Enabled);
            PostPetButton.Click();
            WebDriverExtensions.FindElement(Driver, TryItOutPostOrderButton, Data.WaitTime).Click();
            Driver.GetWait().Until(d => OrderTextArea.Enabled);
            OrderTextArea.Clear();
            OrderTextArea.SendKeys(GetPetTxt());
            WebDriverExtensions.FindElement(Driver, ExecuteButton, Data.WaitTime).Click();
            PostPetButton.Click();
        }

        public void PostOrder()
        {
            Driver.GetWait().Until(d => Driver.FindElement(PostOrderButton).Enabled);
            Driver.FindElement(PostOrderButton).Click();
            WebDriverExtensions.FindElement(Driver, TryItOutPostOrderButton, Data.WaitTime).Click();
            Driver.GetWait().Until(d => PetTextArea.Enabled);
            PetTextArea.Clear();
            PetTextArea.SendKeys(GetOrderTxt());
            WebDriverExtensions.FindElement(Driver, ExecuteButtonOrder, Data.WaitTime).Click();
        }

        public void PressGetByIdButton()
        {
            Driver.GetWait().Until(d => GetByIdButton.Enabled);
            GetByIdButton.Click();
        }
        public void PressFindByStatus()
        {
            WebDriverExtensions.FindElement(Driver, FindByStatusButton, Data.WaitTime).Click();
        }

        public void PressDeleteByIdButton()
        {
            WebDriverExtensions.FindElement(Driver, DeleteByIdButton, Data.WaitTime).Click();
        }

        public void EnterId(long id)
        {
            WebDriverExtensions.FindElement(Driver, TryItOutButton, Data.WaitTime).Click();
            WebDriverExtensions.FindElement(Driver, PetIdInput, Data.WaitTime).SendKeys(Convert.ToString(id));
        }

        public void EnterIdForDelete(string id)
        {
            WebDriverExtensions.FindElement(Driver, TryItOutButtonDelete, Data.WaitTime).Click();
            WebDriverExtensions.FindElement(Driver, PetIdInputDelete, Data.WaitTime).SendKeys(id);
        }

        public void ChooseStatus(string status)
        {
            WebDriverExtensions.FindElement(Driver, TryItOutButtonStatus, Data.WaitTime).Click();
            new SelectElement(Driver.FindElement(StatusSelect)).SelectByValue(status);
            WebDriverExtensions.FindElement(Driver, ExecuteButtonStatus, Data.WaitTime).Click();
        }

        public void EnterIdForFindByStatus(long id)
        {
            WebDriverExtensions.FindElement(Driver, TryItOutButtonStatus, Data.WaitTime).Click();
            WebDriverExtensions.FindElement(Driver, PetIdInput, Data.WaitTime).SendKeys(Convert.ToString(id));
        }

        public void EnterApi_key(string key)
        {
            WebDriverExtensions.FindElement(Driver, Api_keyInput, Data.WaitTime).Clear();
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

        public void ExecuteFindByStatus()
        {
            WebDriverExtensions.FindElement(Driver, ExecuteButtonStatus, Data.WaitTime).Click();
        }

        public int GetResponseCode()
        {
            WebDriverExtensions.FindElement(Driver, ResponseCode, Data.WaitTime);
            var strCode = Driver.FindElement(ResponseCode).Text;
            var resultString = Regex.Match(strCode, @"\d+").Value;
            var code = Convert.ToInt32(resultString);

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

        public int GetPostOrderResponseCode()
        {
            WebDriverExtensions.FindElement(Driver, ResponseCodeOrder, 30);
            var strCode = Driver.FindElement(ResponseCodeOrder).Text;
            var resultString = Regex.Match(strCode, @"\d+").Value;
            var code = Convert.ToInt32(resultString);

            return code;
        }

        public int GetStatusResponseCode()
        {
            WebDriverExtensions.FindElement(Driver, ResponseCodeStatus, Data.WaitTime);
            var strCode = Driver.FindElement(ResponseCodeStatus).Text;
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
        private string GetOrderTxt()
        {
            StreamReader sr = new StreamReader(Globals.OrderPath);
            var ordTxt = sr.ReadToEnd();
            sr.Close();

            return ordTxt;
        }

        public bool IsPetExistsWithThisStatus(long id, string name)
        {
            WebDriverExtensions.FindElement(Driver, ResponseData, Data.WaitTime);
            var text = Driver.FindElement(ResponseData).Text;

            return text.Contains(Convert.ToString(id)) && text.Contains(name);
        }
    }
}
