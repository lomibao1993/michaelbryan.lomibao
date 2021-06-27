using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanItTestAutomation.Pages;
using System;

namespace PlanItTestAutomation
{
    [TestClass]
    public class TestScripts : TestBase
    {
        [TestMethod]
        public void TestCase1()
        {
            var homePage = new HomePage();
            IContactPage contactPage = homePage.GotoContactPage();
            contactPage.ClickSubmitButton();
            Assert.IsTrue(contactPage.VerifyErrorMessageDisplay(), "Error message is not displayed.");
            contactPage.EnterForeName("Michael Bryan");
            contactPage.EnterEmail("lomibao_1993@yahoo.com");
            contactPage.EnterMessage("test message");
            Assert.IsFalse(contactPage.VerifyErrorMessageDisplay(), "Error message is displayed.");
        }

        [TestMethod]
        public void TestCase2()
        {
            var homePage = new HomePage();
            IContactPage contactPage = homePage.GotoContactPage();
            contactPage.EnterForeName("Michael Bryan");
            contactPage.EnterEmail("lomibao_1993@yahoo.com");
            contactPage.EnterMessage("test message");
            contactPage.ClickSubmitButton();
            Assert.IsTrue(contactPage.VerifySucessfulMessageDisplayed(), "Successful message is not displayed.");
        }


        [TestMethod]
        public void TestCase3_TestCase4()
        {
            var homePage = new HomePage();
            IShopPage shopPage = homePage.GotoShopPage();
            shopPage.SelectItems(Toys.FunnyCow, 2);
            shopPage.SelectItems(Toys.FluffyBunny, 5);
            shopPage.SelectItems(Toys.StuffedFrog, 2);
            shopPage.SelectItems(Toys.ValentineBear, 3);
            ICartPage cartPage = homePage.GotoCartPage();
            Assert.IsTrue(cartPage.ValidateAddedItemsIsDisplayed(Toys.FunnyCow, "$10.99", "2"), Toys.FunnyCow + " has incorrect cart details");
            Assert.IsTrue(cartPage.ValidateAddedItemsIsDisplayed(Toys.FluffyBunny, "$9.99", "5"), Toys.FluffyBunny + " has incorrect cart details");
            Assert.IsTrue(cartPage.ValidateAddedItemsIsDisplayed(Toys.StuffedFrog, "$10.99", "2"), Toys.StuffedFrog + " has incorrect cart details ");
            Assert.IsTrue(cartPage.ValidateAddedItemsIsDisplayed(Toys.ValentineBear, "$14.99", "3"), Toys.StuffedFrog + " has incorrect cart details ");
            Assert.IsTrue(cartPage.ValidateTotalPrice(), "Incorrect total price");
        }
    }
}
