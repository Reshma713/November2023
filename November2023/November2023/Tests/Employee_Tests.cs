using November_2023.Pages;
using November_2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace November_2023.Tests
{ 
    [Parallelizable]
    [TestFixture]
    public class Employee_Tests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        EmployeePage employeePageObject = new EmployeePage();
        [SetUp]
        public void TimeSetUp()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
           
            loginPageObj.LoginActions(driver);

            // Home page object initialization and deifinition
            
            homePageObj.GoToEmployeePage(driver);
        }

        [Test, Order(1), Description("This test is creating a new Time record")]
        public void Create_Employee()
        {
            // TM Page object initialization and definition
           
            employeePageObject.Create_Employee();
        }

        [Test, Order(2), Description("This test is editing an existing Time record")]
        public void Edit_Employee()
        {
            employeePageObject.Edit_Employee();
        }


        [Test, Order(3), Description("This test is deleting an existing Time record")]
        public void Delete_Employee()
        {
            
            employeePageObject.Delete_Employee();
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
