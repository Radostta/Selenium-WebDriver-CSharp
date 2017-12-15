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
    class HomePageTests : DesktopSeleniumTestFixturePrototype
    {
        public HomePageTests(Browsers browser) : base(browser)
        { }

        [Test]
        public void NavigateToHomePageTest()
        {
            var homePageInstance = HomePage.NavigateTo(this.Driver);
            Thread.Sleep(4000);
        }

        [Test]
        public void SearchTest()
        {
            Driver.Navigate().GoToUrl("http://store.demoqa.com/");

            string searchText = "White";
            //searching in the html elements of that class: .search - with a dot

            var searchTextBox = this.Driver.FindElement(By.ClassName("search"));
            searchTextBox.SendKeys(searchText);

            searchTextBox.SendKeys(Keys.Enter);

            Thread.Sleep(6000);

            var searchResults = this.Driver.FindElements(By.CssSelector(".prodtitle a"));

            for (int i = 0; i < searchResults.Count; i++)
            {
                string currentSearchResult = searchResults[i].Text;
                Assert.IsTrue(currentSearchResult.Contains(searchText));
            }

            searchText = "Black";
            //searching in the html elements of that class: .search - with a dot

            searchTextBox = this.Driver.FindElement(By.ClassName("search"));
            searchTextBox.SendKeys(searchText);

            searchTextBox.SendKeys(Keys.Enter);

            Thread.Sleep(6000);

            searchResults = this.Driver.FindElements(By.CssSelector(".prodtitle a"));

            for (int i = 0; i < searchResults.Count; i++)
            {
                string currentSearchResult = searchResults[i].Text;
                Assert.IsTrue(currentSearchResult.Contains(searchText));
            }

        }
    }
}
