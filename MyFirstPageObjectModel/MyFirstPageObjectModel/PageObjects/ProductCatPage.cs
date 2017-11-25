using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MyFirstPageObjectModel.PageObjects
{
    public class ProductCatPage
    {
        private IWebDriver Driver;

        public ProductCatPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "prodtitle")]
        private IWebElement firstProduct;

        public void clickOnAddtoCart()
        {
            firstProduct.Click();
        }
    }
}