using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumFirstLectionDemo
{
    //After opening a new Test project in Visual Studio, we need to add Selenium:
    //GOTO: Projects -> Manage NuGet Packages -> search Selenium in "Browse"
    //Download: Selenium WebDriver, Selenium Support, Selenium.Chrome.WebDriver, Firefox.Chrome.WebDriver


    [TestClass]                //tag for unit tests
    public class LectionDemo   //Public class UnitTest1 is a test suite, in which we can create methods, rename it accordingly
    {

        //If we are not using NUnit as a test runner, we can use the test runner in Visual Studio (accessed in Test Explorer)
        //To view the window: Test -> Windows -> Test Explorer

        //BUILD: To see the tests in test explorer, first: Build -> Build Solution;
        //Then we can run all tests (test methods) or -> right click: run selected tests;

        //Tags tell the class what functions will be used:
        //Available function tags when using Microsoft.VisualStudio.TestTools.UnitTesting (MSTest):

        //[ClassInitialize] - executes once before all test cases \ NUnit test class consists of: [OneTimeSetUp]
        //[TestInitialize] - executes before each test \ NUnit: [SetUp]
        //[TestMethod] - tests are defined here \ NUnit: [Test]
        //[TestCleanup] - executes after each test \NUnit: [TearDown]
        //[ClassCleanup] - executes after all tests are done \ [OneTimeTearDown] - executes once per run after all tests

        private IWebDriver Driver; //Select: using openQA Selenium -> creating a new instance with name "Driver" to define the interface through which user controls the browser

        [TestInitialize] //Here we write all that will be executed before every test written below
        public void OpenBrowser()   //the function does not return anything and does not have params
        {
            this.Driver = new ChromeDriver();  //add using QA.Selenium.Chrome
        }

        //Writing the tests:
        //Using page: demoqa.com/registration/

        [TestMethod] //in NUnit: [TestFixture]
        public void TestMethod1() //the name of the test/ functionality
        {
            //first we need to tell the Driver which URL to go to (including whole path with http://):
            //This is the information, included in a page class, if we were using a Page Object Pattern:
            this.Driver.Navigate().GoToUrl("http://demoqa.com/registration/");

            var firstNameTextBox = Driver.FindElement(By.Id("name_3_firstname"));
            //FindElement returns only one element and throws an exception
            //FindElements looks for an array of elements and returns 0, but with no exception
            //In the brackets: By. -> choose the type of selectors that we will choose (right click - inspect - on the site)
            //We paste the selector from the HTML document inside ""

            //firstNameTextBox. will show us what actions we can take on this element in the page
            //SendKeys simulates input from a keyboard
            firstNameTextBox.SendKeys("Valid First Name");

            Thread.Sleep(3000);  //add using System.Threading
            //3000 miliseconds so that the browser will not close immeadiately

            //Finding the registration action button - in this case it is tagged list item - and testing whether the link inside it has the text name "Registration"
            var registrationButton = Driver.FindElement(By.Id("menu-item-374"));
            string regButtonText = registrationButton.Text;

            Assert.AreEqual("Registration", regButtonText); //AreEqual for strings - first ER, second - AR

            Thread.Sleep(3000);
        }

        [TestCleanup] //Here we write all that will be executed after every test like CLOSE THE BROWSER
        public void CloseBrower()
        {
            this.Driver.Close();
        }        
    }
}
