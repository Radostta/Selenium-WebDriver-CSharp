using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebDriverTemplateProject.Pages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Helpers
{
    public static class PageFactoryExtensions
    {
        public static T InitPage<T>(IWebDriver driver) where T : Page
        {
            T page = Activator.CreateInstance(typeof(T)) as T;
            PageFactory.InitElements(driver, page);
            return page;
        }
    }
}
