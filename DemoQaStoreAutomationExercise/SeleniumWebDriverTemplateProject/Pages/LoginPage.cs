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
    public class LoginPage : Page
    {
        [FindsBy(How = How.LinkText, Using = "Home")]
        public IWebElement HomeButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Product Category")]
        public IWebElement ProductCategoryPage { get; set; }

        [FindsBy(How = How.LinkText, Using = "All Product")]
        public IWebElement AllProductButton { get; set; }

        [FindsBy(How = How.Id, Using = "log")]
        public IWebElement UserNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "pwd")]
        public IWebElement PasswordTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement LoginButton { get; set; }

        public static string Path { get { return "/products-page/your-account/"; } }

        public static LoginPage NavigateTo(IWebDriver driver)
        {
            string baseURL = GeneralSettings.Default.BaseURL;
            driver.Navigate().GoToUrl(baseURL);

            if (driver.Manage().Cookies.AllCookies.Any())
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Navigate().GoToUrl(baseURL);
            }

            driver.Navigate().GoToUrl(baseURL + Path);

            var loginPageInstance = PageFactoryExtensions.InitPage<LoginPage>(driver);

            //Page.GlobalWait(driver).Until(d => driver.FindElements(By.Id("lfootercc")).Any());

            return loginPageInstance;
        }

        public void ValidLogIn()
        {
            this.UserNameTextBox.SendKeys(GeneralSettings.Default.UserName);
            this.PasswordTextBox.SendKeys(GeneralSettings.Default.Password);
            this.LoginButton.Click();

            // added because of firefox rushing
            System.Threading.Thread.Sleep(3000);
        }

        public void LogIn(string username, string password)
        {
            this.UserNameTextBox.SendKeys(username);
            this.PasswordTextBox.SendKeys(password);
        }
    }
}
