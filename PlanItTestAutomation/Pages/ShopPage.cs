using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanItTestAutomation.Pages
{
    public interface IShopPage
    {
        void SelectItems(Enum item, int quantity);
    }

    internal class ShopPage : BasePageObject, IShopPage
    {
        public void SelectItems(Enum item , int count)
        {
            var itemList = productItemsListWebElement();
            foreach (var product in itemList)
            {
                var productName = product.FindElement(By.CssSelector(".product-title")).Text;
                var productPrice = product.FindElement(By.CssSelector(".product-price")).Text;
                if (productName.Replace(" ", String.Empty).ToLower() == item.ToString().ToLower())
                {
                    while (count > 0)
                    {
                        product.FindElement(By.CssSelector(".btn.btn-success")).Click();
                        count--;
                    }
                }
            }
        }

        // WebElement
        private IList<IWebElement> productItemsListWebElement()
        {
            var items = Driver.FindElements(By.CssSelector(".product.ng-scope"));
            return items;
        }
    }
}
