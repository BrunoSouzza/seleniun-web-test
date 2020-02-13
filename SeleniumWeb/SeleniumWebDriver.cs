using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace SeleniumWeb
{
    [TestClass]
    public class SeleniumWebDriver
    {
        [TestMethod]
        public void ExplicitWait()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.uitestpractice.com/Students/Contact";
            driver.FindElement(By.PartialLinkText("This is")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("ContactUs")));
            string result = driver.FindElement(By.ClassName("ContactUs")).Text;

            Console.WriteLine(result.Contains("Python")); ;
            driver.Quit();
        }

        [TestMethod]
        public void ExtractTabela()
        {
            var driver = new FirefoxDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://www.redmine.org//projects//redmine//issues");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath(".//*[@class='per-page']/a[2]")).Click();
            int num_of_clicks = Int32.Parse(driver.FindElement(
                    By.XPath(".//*[@id='content']/p[1]/a[3]")).Text);
            for (byte i = 1; i < num_of_clicks; i++)
            {
                IList<IWebElement> records_in_page = driver.FindElements(By.XPath(".//*[@class='list issues']/tbody/tr"));
                for (byte j = 0; j < records_in_page.Count; j++)
                {
                    String Issue_Subject = driver.FindElement(
                            By.XPath(".//*[@class='list issues']/tbody/tr[" + (j + 1)
                                    + "]/td[5]")).Text;
                    Console.WriteLine(Issue_Subject);
                }
                driver.FindElement(By.XPath(".//*[@class='next']")).Click();
            }
        
        }
    }
}
