using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanItTestAutomation
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void SetUpChromeDriver()
        {
            WebDriverManager.SetDriver();
        }

        [TestCleanup]

        public void CleanUpDriver()
        {
            WebDriverManager.CleanUp();
        }
    }
}
