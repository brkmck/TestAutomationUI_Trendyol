using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TrendyolTestAutomationUITest.PageModels
{
    public class BasePage
    {
        private IWebDriver webDriver;

        public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void ClickElement(IWebElement element)
        {
            Wait(10, element);
            element.Click();
        }

        public void SetText(IWebElement element, string text)
        {
            Wait(10, element);
            element.SendKeys(text);
            element.SendKeys(Keys.Tab);
        }

        public void HoverElement(IWebElement element)
        {
            Wait(10, element);
            Actions action = new Actions(this.webDriver);
            action.MoveToElement(element).Build().Perform();
        }

        public string GetCurrentUrl()
        {
            return webDriver.Url;
        }

        public void Wait(int second, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(second));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
