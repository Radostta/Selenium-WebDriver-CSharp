using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstPageObjectModel.PageObjects
{
    class ProductPage
    {
        private IWebDriver Driver;

        public ProductPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "wpsc_buy_button")]
        private IWebElement addToCart;

        public void clickOnAddtoCart()
        {
            addToCart.Click();
        }
    }
}
