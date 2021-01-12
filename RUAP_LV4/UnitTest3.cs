using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class BuyWithoutRegistration
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheBuyWithoutRegistrationTest()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Electronics")).Click();
            driver.FindElement(By.XPath("//img[@alt='Picture for category Cell phones']")).Click();
            driver.FindElement(By.XPath("//input[@value='Add to cart']")).Click();
            driver.FindElement(By.XPath("//li[@id='topcartlink']/a/span")).Click();
            driver.FindElement(By.Id("termsofservice")).Click();
            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.XPath("//input[@value='Checkout as Guest']")).Click();
            driver.FindElement(By.Id("BillingNewAddress_FirstName")).Click();
            driver.FindElement(By.Id("BillingNewAddress_FirstName")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_FirstName")).SendKeys("Ivan");
            driver.FindElement(By.Id("BillingNewAddress_LastName")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_LastName")).SendKeys("Ivic");
            driver.FindElement(By.Id("BillingNewAddress_Email")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_Email")).SendKeys("ivo@gmail.com");
            driver.FindElement(By.Id("BillingNewAddress_CountryId")).Click();
            new SelectElement(driver.FindElement(By.Id("BillingNewAddress_CountryId"))).SelectByText("Andorra");
            driver.FindElement(By.XPath("//option[@value='90']")).Click();
            driver.FindElement(By.Id("BillingNewAddress_City")).Click();
            driver.FindElement(By.Id("BillingNewAddress_City")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_City")).SendKeys("Andor");
            driver.FindElement(By.Id("BillingNewAddress_Address1")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_Address1")).SendKeys("Andor 1");
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).SendKeys("23132");
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).SendKeys("231213123");
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            System.Threading.Thread.Sleep(1000);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,500);");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath("(//input[@value='Continue'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@value='Continue'])[3]")).Click();
            driver.FindElement(By.XPath("(//input[@value='Continue'])[4]")).Click();
            driver.FindElement(By.XPath("(//input[@value='Continue'])[5]")).Click();
            driver.FindElement(By.XPath("//input[@value='Confirm']")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
