using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstPageObjectModel.PageObjects
{
    class LoginPage
    {
        private IWebDriver Driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.Id, Using = "user_login")]
        private IWebElement usernameOrEmailField;

        [FindsBy(How = How.Id, Using = "user_pass")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "wp-submit")]
        private IWebElement loginSubmitButton;


        public void EnterUsernameOrEmail(string usernameOrEmail)
        {
            usernameOrEmailField.SendKeys("ValidUsername");
        }

        public void EnterPassword()
        {
            password.Submit();  //SendKeys("ValidPassword");
        }

        public void SubmitLoginForm()
        {
            loginSubmitButton.Click();
        }
    
        //public ResultPage search(string text)
        //{
        //    searchText.SendKeys(text);
        //    wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#sidebar .searchsubmit"))).Click();
        //    return new ResultPage(driver);
        //}
    }
}
