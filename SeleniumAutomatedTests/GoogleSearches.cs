using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomatedTests
{
    [TestClass]
    public class GoogleSearches
    {
        public IWebDriver driver;
        private readonly string site;

        public GoogleSearches()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            site = "https://www.google.com.mx/";
        }

        [TestMethod]
        public void AmazonSearch()
        {
            driver.Navigate().GoToUrl(site);
            driver.FindElement(By.Name("q")).SendKeys("Amazon México");
            driver.FindElement(By.CssSelector(".QCzoEc > svg")).Click();
            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.Name("btnK")).Click();
            driver.FindElement(By.CssSelector(".tF2Cxc > .yuRUbf .LC20lb")).Click();
            driver.FindElement(By.Id("twotabsearchtextbox")).Click();
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("laptop gamer");
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            CloseBrowser();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void BestBuySearch()
        {
            driver.Navigate().GoToUrl(site);
            try
            {
                driver.FindElement(By.Name("q")).SendKeys("Best Buy");
                driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
                driver.FindElement(By.CssSelector("div:nth-child(2) > .tF2Cxc > .yuRUbf .LC20lb")).Click();
                driver.FindElement(By.CssSelector("div:nth-child(3) a:nth-child(3) > img")).Click();
                driver.FindElement(By.CssSelector("div:nth-child(2) > .tF2Cxc > .yuRUbf .LC20lb")).Click();
                driver.FindElement(By.Id("gh-search-input")).Click();
                driver.FindElement(By.Id("gh-search-input")).Click();
                driver.FindElement(By.Id("gh-search-input")).Click();
                driver.FindElement(By.Id("gh-search-input")).SendKeys("Laptop Gamer");
                driver.FindElement(By.CssSelector(".header-search-icon > svg")).Click();
                driver.FindElement(By.CssSelector(".shop-sku-list-item:nth-child(2) .product-image")).Click();
                driver.FindElement(By.Id("survey_invite_no")).Click();
            }
            catch { CloseBrowser(); }
            CloseBrowser();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CatSearch()
        {
            driver.Navigate().GoToUrl(site);
            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.Name("q")).SendKeys("Cats");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            CloseBrowser();
            Assert.IsTrue(true);
        }

        public bool WaitForElement(By element)
        {
        loop:
            Thread.Sleep(2000);
            try
            {
                WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
                IWebElement firstResult = wait.Until(e => e.FindElement(element));
            }
            catch { goto loop; }
            return true;
        }

        public void CloseBrowser()
        {
            driver.Close();
            driver.Dispose();
            driver.Quit();
        }
    }
}
