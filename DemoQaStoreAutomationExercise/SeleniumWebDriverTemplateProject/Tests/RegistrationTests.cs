using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Tests
{
    class RegistrationTests : DesktopSeleniumTestFixturePrototype
    {
        public RegistrationTests(Browsers browser) : base(browser)
        { }

        [Test]
        public void RegisterUser()
        {
            //Using the POM, this is executed automatically by:
            //Using SeleniumTextFixturePrototype.cs:
            //this.Driver = new ChromeDriver();
            //this.Driver.Manage().Window.Maximize();

            //Not using POM we need to declare here:
            //IWebDriver driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
            //down below we need to use driver.FindElement... instead of this.Driver.FindElement
            //At the end of the test, close the browser: Driver.Quit();

            Driver.Navigate().GoToUrl("http://store.demoqa.com/wp-login.php?action=register");

            string username = Faker.Name.First() + Faker.Name.Last();
            string email = username + "@nosuchmail8579";

            var usernameTextBox = this.Driver.FindElement(By.Id("user_login"));
            usernameTextBox.SendKeys(username);

            var emailTextBox = this.Driver.FindElement(By.Id("user_email"));
            emailTextBox.SendKeys(email);

            var registerButton = this.Driver.FindElement(By.Id("wp-submit"));
            registerButton.Click();

            Thread.Sleep(6000);

            //var messages = this.Driver.FindElements(By.ClassName("message"));
            //int messagesCount = messages.Count;

            //Assert.IsTrue(messagesCount > 0);

            var message = this.Driver.FindElement(By.ClassName("message"));            

            //Assert.IsTrue(message.Displayed);
            Assert.AreEqual("Registration complete.Please check your email.", message.Text);

        }

    }
}
