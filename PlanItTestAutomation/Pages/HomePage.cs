using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanItTestAutomation.Pages
{

    public interface IHomePage {
        IContactPage GotoContactPage();
        IShopPage GotoShopPage();
    }

    internal class HomePage : BasePageObject , IHomePage
    {
        public HomePage()
        {
            Driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
        }

        public IContactPage GotoContactPage()
        {
            contactLinkElement().Click();
            return new ContactPage();
        }

        public IShopPage GotoShopPage()
        {
            shopLinkElement().Click();
            return new ShopPage();
        }

        //WebElements
        private IWebElement contactLinkElement()
        {
            return Driver.FindElement(By.CssSelector("#nav-contact"));
        }

        private IWebElement shopLinkElement()
        {
            return Driver.FindElement(By.CssSelector("#nav-shop"));
        }
    }
}
