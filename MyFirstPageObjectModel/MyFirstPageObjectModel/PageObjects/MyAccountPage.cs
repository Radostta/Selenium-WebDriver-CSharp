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
    public class MyAccountPage
    {
        private IWebDriver Driver;
        private WebDriverWait wait;

        public MyAccountPage(IWebDriver driver)
        {
            this.Driver = Driver;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#meta > ul > li:nth-child(2) > a")]
        private IWebElement loginSidebarLink;

        //public LoginPage GoToLoginPage()
        //{
        //    loginSidebarLink.Click();
        //    return new LoginPage(Driver);
        //}
        
    }
}