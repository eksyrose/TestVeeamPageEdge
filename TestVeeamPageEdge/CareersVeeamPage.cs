using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestVeeamPageEdge
{
    public class CareersVeeamPage //realising PageObject Pattern
    {
        private readonly WebDriver webDriver;
        private readonly WebDriverWait wait;

        public CareersVeeamPage(WebDriver webDriver)
        {
            this.webDriver = webDriver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(1000));
        }

        public void SelectDepartment(string inputDepartment)
        {
            var department = webDriver.FindElements(By.Id("sl"))[0];
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(department)); // Waiting for the element to be clickable
            department.Click();
            IWebElement selectDepartment = webDriver.FindElement(By.LinkText(inputDepartment));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selectDepartment)); // Waiting for the element to be clickable
            selectDepartment.Click();
        }

        public void SelectLanguage(string inputLanguage)
        {
            var language = webDriver.FindElements(By.Id("sl"))[1];
            language.Click();
            IWebElement selectLanguage = language.FindElement(By.XPath("..//label[contains(text(), '" + inputLanguage + "')]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selectLanguage)); // Waiting for the element to be clickable
            selectLanguage.Click();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> GetJobs()
        {
            return webDriver.FindElements(By.XPath("//div[contains(@class, 'card-body')]"));
        }
    }
}
