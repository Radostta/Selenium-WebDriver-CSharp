using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Pages.Abstract
{
    public abstract class Page
    {
        IWebDriver Driver { get; set; }

        public static WebDriverWait GlobalWait(IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(GeneralSettings.Default.ForcedWait));
        }
    }
}
