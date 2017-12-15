using NUnit.Framework;
using SeleniumWebDriverTemplateProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Tests.Abstract
{
    //If you need to add/remove a browser from a group of tests, you can do so here
    [TestFixture(Browsers.Chrome)]
    [TestFixture(Browsers.Firefox)]
    //[TestFixture(Browsers.IE)]
    //bear in mind that test fixtures that are not declared as abstract will apear in the Nunit as such even if they contain no tests
    public abstract class DesktopSeleniumTestFixturePrototype : SeleniumTestFixturePrototype
    {
        public DesktopSeleniumTestFixturePrototype(Browsers browser)
            : base(browser)
        {

        }
    }
}
