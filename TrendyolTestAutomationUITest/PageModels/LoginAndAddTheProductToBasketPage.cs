using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace TrendyolTestAutomationUITest.PageModels
{
    public class LoginAndAddTheProductToBasketPage : BasePage
    {
        private IWebDriver webDriver;
        private static ILog log;
        Random rnd = new Random();

        public LoginAndAddTheProductToBasketPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//div[@class='link account-user']")]
        public IWebElement btnLoginHover;

        [FindsBy(How = How.XPath, Using = "//div[@class='login-button']")]
        public IWebElement btnLogin;

        [FindsBy(How = How.XPath, Using = "//a[@title='Close']")]
        public IWebElement btnCloseMainPopup;

        [FindsBy(How = How.XPath, Using = "//input[@id='login-email']")]
        public IWebElement txtEmail;

        [FindsBy(How = How.XPath, Using = "//input[@id='login-password-input']")]
        public IWebElement txtPasword;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'submit')]")]
        public IWebElement btnSubmit;

        [FindsBy(How = How.XPath, Using = "//*[@class='main-nav']/li")]
        public IList<IWebElement> tabCategories;

        [FindsBy(How = How.XPath, Using = "//div[@title='Kapat']")]
        public IWebElement btnCloseLoginPopup;

        [FindsBy(How = How.XPath, Using = "//article[@class='component-item']/a/summary/span")]
        public IList<IWebElement> boutiqueList;

        [FindsBy(How = How.XPath, Using = "//article[@class='component-item']")]
        public IList<IWebElement> boutiqueNameList;

        [FindsBy(How = How.XPath, Using = "//div[@class='boutique-product card']")]
        public IList<IWebElement> productList;

        [FindsBy(How = How.XPath, Using = "//div[@class='boutique-product']/a/div[3]//div/span[@class='name']")]
        public IList<IWebElement> productNames;

        [FindsBy(How = How.XPath, Using = "//button[@class='pr-in-btn add-to-bs']")]
        public IWebElement btnAddToBasket;
        #endregion

        public void CloseMainPopup()
        {
            Wait(10, btnCloseMainPopup);
            if (btnCloseMainPopup.Displayed)
            {
                ClickElement(btnCloseMainPopup);
            }
            else
            {
                log.Error("Popup kapanamadı.");
            }
        }

        public void ClickToLogin()
        {
            HoverElement(btnLoginHover);
            ClickElement(btnLogin);
        }

        public void SetEmailAdress(string emailAdress)
        {
            SetText(txtEmail, emailAdress);
        }

        public void SetPassword(string password)
        {
            SetText(txtPasword, password);
        }

        public void ClickSubmitLogin()
        {
            ClickElement(btnSubmit);
        }

        public void CloseLoginPopup()
        {
            Wait(10, btnCloseLoginPopup);
            if (btnCloseLoginPopup.Displayed)
            {
                ClickElement(btnCloseLoginPopup);
            }
            else
            {
                log.Error("Popup kapanamadı.");
            }
        }

        public void CheckCategories()
        {
            for (int i = 0; i < tabCategories.Count; i++)
            {
                if (!tabCategories[i].Displayed)
                {
                    string categoriName = tabCategories[i].Text;
                    log.Error($"{categoriName} kategorisi yüklenemedi.");
                }
                ClickElement(tabCategories[i]);
                CheckBoutiques();
            }
        }

        public void CheckBoutiques()
        {
            for (int i = 0; i < boutiqueList.Count; i++)
            {
                IWebElement boutique = boutiqueList[i];
                if (!boutique.Displayed)
                {
                    string boutiqueName = boutique.Text;
                    log.Error($"{boutiqueName} isimli butik yüklenemedi.");
                }
            }
        }

        public void ClickRandomCategory()
        {
            int randomCategoryNumber = rnd.Next(1, tabCategories.Count - 1);
            ClickElement(tabCategories[randomCategoryNumber]);
        }

        public void ClickRandomBoutique()
        {
            int randomBoutique = rnd.Next(1, boutiqueNameList.Count - 1);
            ClickElement(boutiqueNameList[randomBoutique]);
        }

        public void CheckProduct()
        {
            ClickRandomBoutique();
            for (int i = 0; i < productList.Count; i++)
            {
                IWebElement product = productList[i];
                if (!product.Displayed)
                {
                    string productName = productNames[i].Text;
                    log.Error($"{productName} ürünü yüklenemedi.");
                }
            }
        }

        public void ClickRandomProduct()
        {
            int randomProduct = rnd.Next(0, productNames.Count - 1);
            ClickElement(productNames[randomProduct]);
        }

        public void ClickAddToBasket()
        {
            Wait(10, btnAddToBasket);
            if (!btnAddToBasket.Displayed)
            {
                log.Error("Ürün detay sayfası yüklenemedi.");
            }
            ClickElement(btnAddToBasket);
        }
    }
}
