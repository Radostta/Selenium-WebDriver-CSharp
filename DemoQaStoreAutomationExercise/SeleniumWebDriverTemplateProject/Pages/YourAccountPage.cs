using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Pages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Pages
{
    class YourAccountPage : Page
    {
        [FindsBy(How = How.LinkText, Using = "Home")]
        public IWebElement HomeButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Product Category")]
        public IWebElement ProductCategoryPage { get; set; }

        [FindsBy(How = How.LinkText, Using = "All Product")]
        public IWebElement AllProductButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#account a")]
        public IWebElement MyAccountButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "display-name")]
        public IWebElement UserNameTextBox { get; set; }

        public static YourAccountPage NavigateTo(IWebDriver driver)
        {
            var loginPageInstance = LoginPage.NavigateTo(driver);
            loginPageInstance.ValidLogIn();

            var yourAccountPageInstance = PageFactoryExtensions.InitPage<YourAccountPage>(driver);

            return yourAccountPageInstance;
        }
    }
}
