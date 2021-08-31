using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace Test {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Register() {
                IWebDriver driver = new FirefoxDriver();
                driver.Navigate().GoToUrl( "https://moneygaming.qa.gameaccount.com/" );
                driver.Manage().Window.Maximize();
                driver.FindElement( By.XPath( "/html/body/div[2]/div[1]/div[2]/div[1]/a[2]" ) ).Click();
                IWebElement titleDropdownList = driver.FindElement( By.XPath( "/html/body/div[2]/div[3]/form/fieldset[1]/select[1]" ) );
                titleDropdownList.Click();
                SelectElement element = new SelectElement( titleDropdownList );
                element.SelectByValue( "Mr" );
                driver.FindElement( By.XPath( "/html/body/div[2]/div[3]/form/fieldset[1]/input[1]" ) ).SendKeys( "Steven" );
                driver.FindElement( By.XPath( "/html/body/div[2]/div[3]/form/fieldset[1]/input[2]" ) ).SendKeys( "Gee" );
                driver.FindElement( By.XPath( "/html/body/div[2]/div[3]/form/fieldset[5]/input[3]" ) ).Click();
                driver.FindElement( By.XPath( "/html/body/div[2]/div[3]/form/fieldset[6]/input" ) ).Click();
                IWebElement validationDOB = driver.FindElement( By.CssSelector( "#signupForm > fieldset:nth-child(1) > label:nth-child(15)" ) );
                string actualError = validationDOB.Text;
                string expectedError = "This field is required";
                Assert.AreEqual( actualError, expectedError );
                Console.WriteLine( "'This field is required' error message appears under date of birth box. " );
                Console.WriteLine( "Test: PASS " );
                driver.Close();
        }
    }
}