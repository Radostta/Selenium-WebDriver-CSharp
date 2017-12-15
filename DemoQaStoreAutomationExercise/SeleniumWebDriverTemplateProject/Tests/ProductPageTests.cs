using NUnit.Framework;
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
    class ProductPageTests : DesktopSeleniumTestFixturePrototype
    {
        public ProductPageTests(Browsers browser) : base(browser)
        { }

        [Test]
        public void ProductCounterTest()
        {
            var productPageInstance = ProductCategoryPage.NavigateTo(base.Driver);

            var products = productPageInstance.GetProducts();

            products[1].AddToCartButton.Click();

            Thread.Sleep(5000);

            //productPageInstance = PageFactoryExtensions.InitPage<ProductCategoryPage>(this.Driver);

            var countAsAString = productPageInstance.ProductCountTextBox.Text;
            var countAsAnInteger = Convert.ToInt32(countAsAString);

            Assert.AreEqual(1, countAsAnInteger);
        }
    }
}
