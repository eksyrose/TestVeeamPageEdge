using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestVeeamPageEdge
{
    public class CareersVeeamPage //realising PageObject Pattern
    {
        private readonly WebDriver webDriver;

        public CareersVeeamPage(WebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void SelectDepartment(string inputDepartment)
        {
            var department = webDriver.FindElements(By.Id("sl"))[0];
            new WebDriverWait(webDriver, System.TimeSpan.FromMilliseconds(1000)); // Waiting while page loading
            department.Click();
            IWebElement selectDepartment = webDriver.FindElement(By.LinkText(inputDepartment));
            new WebDriverWait(webDriver, System.TimeSpan.FromMilliseconds(1000)); // Waiting while page loading
            selectDepartment.Click();
        }

        public void SelectLanguage(string inputLanguage)
        {
            var language = webDriver.FindElements(By.Id("sl"))[1];
            language.Click();
            IWebElement selectLanguage = language.FindElement(By.XPath("..//label[contains(text(), '" + inputLanguage + "')]"));
            new WebDriverWait(webDriver, System.TimeSpan.FromMilliseconds(1000)); // Waiting while page loading               
            selectLanguage.Click();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> GetJobs()
        {
            return webDriver.FindElements(By.XPath("//div[contains(@class, 'card-body')]"));
        }
    }
}
