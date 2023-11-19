using System;
using NUnit.Framework;

using November_2023.Pages;
using November_2023.Utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Rpc;

namespace November2023.Tests
{
    //all codes transferred from program class

    [Parallelizable]
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObject = new TMPage();
        [SetUp]
        public void TimeSetUp()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            // Login page object definition
            
            loginPageObj.LoginActions(driver);

            // Home page object deifinition
            
            homePageObj.GoToTMPage(driver);
        }

        [Test,Order(1), Description("This test is creating a new Time record")]
        public void CreateTime_Test()
        {
            // TM Page object initialization and definition
          
            tmPageObject.Create_TimeRecord(driver);
        }

        [Test, Order(2), Description("This test is editing an existing Time record")]
        public void EditTime_Test()
        {
           
            // Edit TM..................check
            tmPageObject.Edit_TimeRecord(driver,"anything","two","three");
        }


        [Test, Order(3), Description("This test is deleting an existing Time record")]
        public void DeleteTime_Test()
        {
           
            // Delete TM
            tmPageObject.Delete_TimeRecord(driver);
        }
       
        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}




















// from program class
/*using November_2023.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        //Open Chrome browser
        IWebDriver driver = new ChromeDriver(); //instance of a browser

        // Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        //Home page 
        HomePage homePageObj = new HomePage();
        homePageObj.GoToTMPage(driver);

        // TM Page object initialisation and definition
        TMPage tmPageObject = new TMPage();
        tmPageObject.Create_TimeRecord(driver);

        // Edit TM
        tmPageObject.Edit_TimeRecord(driver);

        //Delete TM
        tmPageObject.Delete_TimeRecord(driver);


    }
}*/