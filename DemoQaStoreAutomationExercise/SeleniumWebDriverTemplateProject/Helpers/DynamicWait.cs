using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Helpers
{
    public static class DynamicWait
    {
        public static int GetWaitLength(IWebDriver driver)
        {
            int forcedWait = GeneralSettings.Default.ForcedWait;

            // put here custom logic to treat every browser differently

            return forcedWait;
        }

        public static void Wait(IWebDriver driver)
        {
            int waitLeght = GetWaitLength(driver);

            // add custom logih here to add driver non-specific factors to the wait chain

            // this should not be used anywhere else in the project

            System.Threading.Thread.Sleep(waitLeght); 
        }
    }
}
