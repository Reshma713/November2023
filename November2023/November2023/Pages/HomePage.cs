using November_2023.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace November_2023.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {

            IWebElement administration = driver.FindElement(By.XPath("/ html / body / div[3] / div / div / ul / li[5] / a"));
            administration.Click();

            Wait.WaitToBeClickable(driver, "XPath","/ html / body / div[3] / div / div / ul / li[5] / ul / li[3] / a",3);

            IWebElement timeandMaterial = driver.FindElement(By.XPath("/ html / body / div[3] / div / div / ul / li[5] / ul / li[3] / a"));
            timeandMaterial.Click();
        }
        public void GoToEmployeePage(IWebDriver driver)
        {

            /*IWebElement administration = driver.FindElement(By.XPath("/ html / body / div[3] / div / div / ul / li[5] / a"));
            administration.Click();
            Wait.WaitToBeClickable(driver, "XPath", "/ html / body / div[3] / div / div / ul / li[5] / ul / li[3] / a", 3);

            IWebElement timeandMaterial = driver.FindElement(By.XPath("/ html / body / div[3] / div / div / ul / li[5] / ul / li[3] / a"));
            timeandMaterial.Click();*/
        }
    }
}
