using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanItTestAutomation.Pages
{
    public interface ICartPage
    {
        bool ValidateAddedItemsIsDisplayed(Enum item, string price , string quantity);
        bool ValidateTotalPrice();
    }

    internal class CartPage : BasePageObject, ICartPage
    {

        public bool ValidateAddedItemsIsDisplayed(Enum item, string price , string count)
        {
            var addedItems = GetCartItems();
            var rightItem = addedItems.FirstOrDefault(x => x.ProductName.Replace(" ", String.Empty).ToLower() == item.ToString().ToLower());
            var calculatedSubTotal = float.Parse(rightItem.ProductPrice.ToString().Replace("$", "")) * int.Parse(rightItem.ProductQuantity.ToString());
            
            return rightItem.ProductName.Replace(" ", String.Empty).ToLower() == item.ToString().ToLower() && rightItem.ProductSubTotal == calculatedSubTotal.ToString() && rightItem.ProductPrice == price && rightItem.ProductQuantity == count;
        }

        public bool ValidateTotalPrice()
        {
            var addedItems = GetCartItems();
            var total = 0.00d;
            foreach(var item in addedItems)
            {
                total = total + double.Parse(item.ProductSubTotal);
            }

            return Math.Round(double.Parse(cartTotalPriceElement().Text.Replace("Total: ", String.Empty)),2) == Math.Round(total,2);
        }

        private IReadOnlyList<CartDetails> GetCartItems()
        {
            var addedItems = new List<CartDetails>();
            var addedItemList = cartItemsListWebElement();
            foreach (var addedItem in addedItemList)
            {
                var productName = addedItem.FindElement(By.CssSelector("td:nth-last-child(5)")).Text.Replace(" ", "");
                var price = addedItem.FindElement(By.CssSelector("td:nth-last-child(4)")).Text;
                var quantity = addedItem.FindElement(By.CssSelector("td:nth-last-child(3) > input")).GetAttribute("value");
                var subtotal = addedItem.FindElement(By.CssSelector("td:nth-last-child(2)")).Text.Replace("$", "");
                addedItems.Add(new CartDetails()
                {
                    ProductName = productName,
                    ProductPrice = price,
                    ProductQuantity = quantity,
                    ProductSubTotal = subtotal
                });
            }
            return addedItems;
        }



        private IReadOnlyList<IWebElement> cartItemsListWebElement()
        {
            var list = Driver.FindElements(By.CssSelector(".cart-item.ng-scope"));
            return list;
        }

        private IWebElement cartTotalPriceElement()
        {
            return Driver.FindElement(By.CssSelector(".total"));
        }

    }
}
