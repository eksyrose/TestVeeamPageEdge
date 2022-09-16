using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

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
        }

        
        [TestCase("Research & Development", "English", 10)]
        [TestCase("Research & Development", "English", 12)]
        public void CountRDEnglishJobs(string inputDepartment, string inputLanguage, int expectedJobsCount)
        {
            _driver.Url = "https://cz.careers.veeam.com/vacancies";
         
            var department = _driver.FindElements(By.Id("sl"))[0]; 
            new WebDriverWait(_driver, System.TimeSpan.FromMilliseconds(1000)); // Waiting while page loading
            department.Click();

            IWebElement selectDepartment = _driver.FindElement(By.LinkText(inputDepartment));
            new WebDriverWait(_driver, System.TimeSpan.FromMilliseconds(1000)); // Waiting while page loading
            selectDepartment.Click();

            var language = _driver.FindElements(By.Id("sl"))[1];
            language.Click();

            IWebElement selectLanguage = language.FindElement(By.XPath("..//label[contains(text(), '" + inputLanguage + "')]"));
            new WebDriverWait(_driver, System.TimeSpan.FromMilliseconds(1000)); // Waiting while page loading               
            selectLanguage.Click();

            int realJobsCount = _driver.FindElements(By.XPath("//div[contains(@class, 'card-body')]")).Count;

            Assert.AreEqual(expectedJobsCount, realJobsCount);
        }

      [TearDown]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
