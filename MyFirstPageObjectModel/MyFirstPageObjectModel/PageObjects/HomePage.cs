using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstPageObjectModel.PageObjects
{
    class HomePage
    {
        //Constructor:

        private IWebDriver Driver;


        public HomePage (IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this); //Helps using FindsBy
        }

        //Defining the page web elements:

        [FindsBy(How = How.CssSelector, Using = "#menu-item-33 > a")]
        private IWebElement productCategoryNavBarLink;

        [FindsBy(How = How.CssSelector, Using = "#account > a")]
        private IWebElement myAccountHeaderLink;

        [FindsBy(How = How.CssSelector, Using = "#menu-item-34 > a")]
        private IWebElement accessoriesDropdownSelection;

        //Defining the page functionalities in page object methods:

        public void GotoPage()
        {
            Driver.Navigate().GoToUrl("http://store.demoqa.com/");
        }

        //some methods return other page objects:

        public ProductCatPage GoToProductCatPage()
        {
            productCategoryNavBarLink.Click();
            return new ProductCatPage(Driver);
        }

        public MyAccountPage GoToMyAccountPage()
        {
            myAccountHeaderLink.Click();
            return new MyAccountPage(Driver);
        }

        public AccessoriesPage GoAccessoriesPage()
        {
            accessoriesDropdownSelection.Click();
            return new AccessoriesPage(Driver);
        }


    }
}
