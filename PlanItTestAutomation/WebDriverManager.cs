using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PlanItTestAutomation
{
    public static class WebDriverManager
    {

        public static IWebDriver WebDriver;

        public static IWebDriver SetDriver()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return WebDriver;
        }

        public static void CleanUp()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }
    }
}
