using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Pages;
using SeleniumWebDriverTemplateProject.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Tests
{
    class LoginTests : DesktopSeleniumTestFixturePrototype
    {
        public LoginTests(Browsers browser) : base(browser)
        { }

        [Test]
        public void LoginTest()
        {
            var loginPageInstance = LoginPage.NavigateTo(base.Driver);

            //loginPageInstance.UserNameTextBox.SendKeys(GeneralSettings.Default.UserName);
            //loginPageInstance.PasswordTextBox.SendKeys(GeneralSettings.Default.Password);

            loginPageInstance.ValidLogIn();

            var yourAccountPage = PageFactoryExtensions.InitPage<YourAccountPage>(this.Driver);

            Thread.Sleep(10000);

            Assert.AreEqual(
                    yourAccountPage.UserNameTextBox.Text, "example"
                );
        }

        [Test]
        public void LoginLogoutTest()
        {
            LoginPage page = LoginPage.NavigateTo(this.Driver);

            var usernameTextBox = this.Driver.FindElement(By.Id("log"));
            usernameTextBox.SendKeys("example@nosuchmail.com");

            var passwordTextBox = this.Driver.FindElement(By.Id("pwd"));
            passwordTextBox.SendKeys("pass1234");

            var loginButton = this.Driver.FindElement(By.Id("login"));
            loginButton.Click();

            Thread.Sleep(3000);

            //var logoutButtons = this.Driver.FindElements(By.CssSelector("a#logo +div a"));
            var logoutButtons = this.Driver.FindElements(By.CssSelector("#account_logout a"));

            int buttonsCount = logoutButtons.Count;

            Assert.IsTrue(buttonsCount > 0);

            logoutButtons[0].Click();

            //Thread.Sleep(6000);

            //logoutButtons = this.Driver.FindElements(By.CssSelector("#account_logout a"));
            //buttonsCount = logoutButtons.Count;

            int timeOut = 15;

            for (int i = 0; i < timeOut; i++)
            {
                logoutButtons = this.Driver.FindElements(By.CssSelector("#account_logout a"));
                buttonsCount = logoutButtons.Count;

                if (buttonsCount == 0)
                {
                    break;
                }

                Thread.Sleep(1000);
            }

            Assert.IsTrue(buttonsCount == 0);
        }
    }
}
