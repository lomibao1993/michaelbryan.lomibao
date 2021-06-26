using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanItTestAutomation.Pages
{
    internal class BasePageObject
    {
        protected IWebDriver Driver => WebDriverManager.WebDriver;
    }
}
