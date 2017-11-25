using OpenQA.Selenium;

namespace MyFirstPageObjectModel.PageObjects
{
    public class AccessoriesPage
    {
        private IWebDriver driver;

        public AccessoriesPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}