using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;


namespace TestVeeamPageEdge
{
    [TestFixture]
    public class EdgeDriverTest
    {
        private EdgeDriver _driver;

        [SetUp]
        public void EdgeDriverInitialize()
        {
            var options = new EdgeOptions // Initialize edge driver 
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            options.AddArgument("--start-maximized"); // Maximize the window
            _driver = new EdgeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }
        
        [TestCase("Research & Development", "English", 10)]
        [TestCase("Research & Development", "English", 13)]
        public void CountRDEnglishJobs(string inputDepartment, string inputLanguage, int expectedJobsCount)
        {
            _driver.Url = "https://cz.careers.veeam.com/vacancies";           
            CareersVeeamPage careersVeeamPage = new CareersVeeamPage(_driver); 
            careersVeeamPage.SelectDepartment(inputDepartment);
            careersVeeamPage.SelectLanguage(inputLanguage);
            int realJobsCount = careersVeeamPage.GetJobs().Count;
            Assert.AreEqual(expectedJobsCount, realJobsCount);
        }

        [TearDown]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
