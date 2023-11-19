using November_2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace November_2023.Pages
{
    public class TMPage
    {
        public void Create_TimeRecord(IWebDriver driver)
        {


            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            // Select time
            IWebElement TypeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            TypeCodeDropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            timeOption.Click();
            IWebElement codeTextbox = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
            codeTextbox.SendKeys("Nov2023");
            IWebElement descriptionTextbox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            descriptionTextbox.SendKeys("Nov2023");
            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("12");
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(4000);
            try
            {
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                goToLastPageButton.Click();  ////*[@id="tmsGrid"]/div[4]/a[4]/span
            }
            catch (Exception ex)
            {
                Assert.Fail("Go to last page button has not been found", ex.Message);
            }
        }
        public string GetCode(IWebDriver driver)
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }
        public string GetDescription(IWebDriver driver)
        {
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetPrice(IWebDriver driver)
        {
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;

        }


        //IWebElement newTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));

        // Assert.That(newTypeCode.Text == "M", "New TypeCode and expected TypeCode do not match.");


        //if (newCode.Text == "Nov2023")
        //{
        //Console.WriteLine("New record has been created successfully");
        //Assert.Pass("New record has been created successfully");

        // }
        // else
        //{

        // Console.WriteLine("New record has not been created");
        //Assert.Fail("New record has not been created");

        //}


        public void Edit_TimeRecord(IWebDriver driver, string code, string description, string price)
        {
            Thread.Sleep(4000);
            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton1.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 10);


            //--------------------------------------------------------------------------Edit record
            IWebElement recordCreated = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (recordCreated.Text == "Nov2023")
            {

                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited has not been found");
            }
            Wait.WaitToExist(driver, "Id", "Code", 10);
        

            //Edit code in the code text box
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            // editCodeTextbox.SendKeys("REditCode");
            editCodeTextbox.SendKeys(code);


            //Edit discription in discription text box
            IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
            editDescriptionTextbox.Clear();
            //editDescriptionTextbox.SendKeys("REditDes");
            editDescriptionTextbox.SendKeys(description);

            //Edit price per unit in price per unit textbox

            //Thread.Sleep(6000);

            IWebElement editPriceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            //editPriceTextbox.Clear();
            editPriceTextbox.SendKeys(price);


            //Save edit data by clicking Save button
            //Wait.WaitToExist(driver, "XPath", "//*[@id=\"SaveButton\"]", 10);

            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();

            Thread.Sleep(6000);
            //Check if record has been edited sucessfully (change the xpath according to the record we created)

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);

            IWebElement goToLastPageButtonEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonEdit.Click();
            Wait.WaitToExist(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 10);
        }
        public string EditedCode(IWebDriver driver)
        {
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedCode.Text;

        }

        public string EditedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;

        }
      
        public string EditedPrice(IWebDriver driver)
        {
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return editedPrice.Text;

        }
        public void Delete_TimeRecord(IWebDriver driver)
        {



        IWebElement goToLastPageButtonEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButtonEdit.Click();

        //Delete record from Time and Material page

        IWebElement editedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (editedRecord.Text == "REditCode")
        {

            IWebElement deletebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deletebutton.Click();
        }
        else
        {
            Assert.Fail("Record to be deletedhas not been found");
        }



        Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 10);

        driver.SwitchTo().Alert().Accept();


    }


}}