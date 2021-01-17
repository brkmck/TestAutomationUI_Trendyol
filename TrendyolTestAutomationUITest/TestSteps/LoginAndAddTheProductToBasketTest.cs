using log4net;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using TrendyolTestAutomationUITest.PageModels;
using TrendyolTestAutomationUITest.Utils;

namespace TrendyolTestAutomationUITest.TestSteps
{
    [Binding, Scope(Feature = "LoginAndAddTheProductToBasket")]
    public class LoginAndAddTheProductToBasketTest
    {
        private static ILog log;
        public static IWebDriver WebDriver { get; set; }
        public BasePage basePage;
        public LoginAndAddTheProductToBasketPage loginAndAddTheProductToBasketPage;
        public Browser browser;
        string driverPath = String.Empty;

        public LoginAndAddTheProductToBasketTest()
        {
            driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            browser = new Browser();
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        [StepDefinition("'(.*)' browser açlır")]
        public void OpenBrowser(string genericDriver)
        {
            switch (genericDriver)
            {
                case "Chrome":
                    WebDriver = browser.SetupChromeDriver(driverPath);
                    break;
                case "Firefox":
                    WebDriver = browser.SetupFirefoxDriver(driverPath);
                    break;
                case "InternetExplorer":
                    WebDriver = browser.SetupInternetExplorer(driverPath);
                    break;
            }
            basePage = new BasePage(WebDriver);
            loginAndAddTheProductToBasketPage = new LoginAndAddTheProductToBasketPage(WebDriver);
        }

        [StepDefinition("'(.*)' sitesine gidilir")]
        public void OpenTrendyol(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
            string currentUrl = basePage.GetCurrentUrl();
            if (!currentUrl.Equals(url))
            {
                log.Error($"{url} sayfası açılmadı!");
            }
        }

        [StepDefinition("Anasayfadaki popup kapatılır")]
        public void CloseMainPopup()
        {
            loginAndAddTheProductToBasketPage.CloseMainPopup();
        }

        [StepDefinition("Giriş Yap butonuna tıklanır")]
        public void ClickToLogin()
        {
            loginAndAddTheProductToBasketPage.ClickToLogin();
            string currentUrl = basePage.GetCurrentUrl();
            if (!currentUrl.Contains("trendyol.com/giris"))
            {
                log.Error("Trendyol login sayfası açılmadı!");
            }
        }

        [StepDefinition("Email adresi '(.*)' girilir")]
        public void SetEmailAdress(string emailAdress)
        {
            loginAndAddTheProductToBasketPage.SetEmailAdress(emailAdress);
        }

        [StepDefinition("Şifre '(.*)' girilir")]
        public void SetPassword(string password)
        {
            loginAndAddTheProductToBasketPage.SetPassword(password);
        }

        [StepDefinition("Giriş Yap butonuna tıklanır ve login olunur")]
        public void ClickSubmitLogin()
        {
            loginAndAddTheProductToBasketPage.ClickSubmitLogin();
        }

        [StepDefinition("Giriş yaptıktan sonra gelen popup kapanır")]
        public void CloseLoginPopup()
        {
            loginAndAddTheProductToBasketPage.CloseLoginPopup();
            string currentUrl = basePage.GetCurrentUrl();
            if (!currentUrl.Contains("trendyol.com/butik/liste/"))
            {
                log.Error("Trendyol ana sayfası açılmadı!");
            }
        }

        [StepDefinition("Kategorilere tıklanarak butiklerin yüklendiği kontrol edilir")]
        public void CheckCategories()
        {
            loginAndAddTheProductToBasketPage.CheckCategories();
        }

        [StepDefinition("Rastgele bir kategoriye tıklanır")]
        public void ClickRandomCategory()
        {
            loginAndAddTheProductToBasketPage.ClickRandomCategory();
        }

        [StepDefinition("Rastgele bir butiğe tıklanarak ürünlerin görselleri kontrol edilir")]
        public void CheckRandomBoutiqueProducts()
        {
            loginAndAddTheProductToBasketPage.CheckProduct();
        }

        [StepDefinition("Rastgele bir ürüne tıklanır")]
        public void ClickRandomProduct()
        {
            loginAndAddTheProductToBasketPage.ClickRandomProduct();
        }

        [StepDefinition("Ürün sepete eklenir")]
        public void ClickAddToBasket()
        {
            loginAndAddTheProductToBasketPage.ClickAddToBasket();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriver.Quit();
        }
    }
}
