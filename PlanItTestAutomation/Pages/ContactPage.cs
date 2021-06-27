using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanItTestAutomation.Pages
{
    public interface IContactPage
    {
        bool VerifyErrorMessageDisplay();
        void ClickSubmitButton();
        void EnterForeName(String foreName);
        void EnterEmail(String email);
        void EnterMessage(String nessage);
        bool VerifySucessfulMessageDisplayed();
    }

    internal class ContactPage : BasePageObject , IContactPage
    {

        public void ClickSubmitButton()
        {
            submitButton().Click();
        }

        public bool VerifyErrorMessageDisplay()
        {
            bool isErrAlert = alertErrorMessage() != null;
            bool isErrForeName = forenameErrorMessage() != null;
            bool isErrEmail = emailErrorMessage() != null;
            bool isErrMessage = messageTxtErrorMessage() != null;
            return isErrAlert && isErrForeName && isErrEmail && isErrMessage;
        }

        public void EnterForeName(String foreName)
        {
            foreNameInput().SendKeys(foreName);
        }

        public void EnterEmail(String email)
        {
            emailInput().SendKeys(email);
        }

        public void EnterMessage(String message)
        {
            messageInput().SendKeys(message);
        }

        public bool VerifySucessfulMessageDisplayed()
        {
            FluentWait().Until(a => successAlertMessage());
            return successAlertMessage().Displayed;
        }

        //WebElements
        private IWebElement submitButton()
        {
            return Driver.FindElement(By.CssSelector(".btn-contact.btn.btn-primary"));
        }

        private IWebElement alertErrorMessage()
        {
            var element =  Driver.FindElements(By.CssSelector(".alert.alert-error.ng-scope"));
            return element.Count > 0 ? element[0] : null;
        }

        private IWebElement forenameErrorMessage()
        {
            var element = Driver.FindElements(By.CssSelector("#forename-err"));
            return element.Count > 0 ? element[0]: null;
        }

        private IWebElement emailErrorMessage()
        {
            var element =  Driver.FindElements(By.CssSelector("#email-err"));
            return element.Count > 0 ? element[0] : null;
        }

        private IWebElement messageTxtErrorMessage()
        {
            var element =  Driver.FindElements(By.CssSelector("#message-err"));
            return element.Count > 0 ? element[0] : null;
        }

        private IWebElement foreNameInput()
        {
            return Driver.FindElement(By.CssSelector("#forename"));
        }

        private IWebElement emailInput()
        {
            return Driver.FindElement(By.CssSelector("#email"));
        }

        private IWebElement messageInput()
        {
            return Driver.FindElement(By.CssSelector("#message"));

        }

        private IWebElement successAlertMessage()
        {
            return Driver.FindElement(By.CssSelector(".alert-success"));
        }
    }
}
