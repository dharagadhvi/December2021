using AutoTestProject.Utililty;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestProject.Pages
{
    internal class TM_Page
    {
        public void Createtm(IWebDriver driver)
        {
            // Click on Create New Button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            // Select Material from TypeCode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            Thread.Sleep(1000);
            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            materialOption.Click();

            // Identify the Code textbox and input a code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("dummycode");

            // Identify the Description textbox and input a description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("may be dummy");

            // Identify the Price textbox and input a price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("420");

            // Click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            System.Threading.Thread.Sleep(5000);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            System.Threading.Thread.Sleep(5000);

            // check if record created is present in the table and has expected value
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (actualCode.Text == "dummycode")
            {
                Console.WriteLine("Material record created successfully, test passed.");
            }
            else
            {
                Console.WriteLine("Test failed.");
            }

        }

        public void EditTM(IWebDriver driver)
        {
            //Edit existing record

            IWebElement findMyRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findMyRecord.Text == "dummycode")
            {

                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();

                IWebElement typeEditcode = driver.FindElement(By.XPath("//*[@id='Code']"));
                typeEditcode.Clear();
                typeEditcode.SendKeys("oldcode");
                Thread.Sleep(2000);

                IWebElement saveEditButton = driver.FindElement(By.Id("SaveButton"));
                saveEditButton.Click();
                Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 5);

                IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                goToLastPageButton1.Click();
                Thread.Sleep(5000);

                IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

                if (editedCode.Text == "oldcode")
                {

                    Console.WriteLine("Record edited successfully");
                }

                else

                {
                    Console.WriteLine("Edit Test Failed");

                }

            }
            else
            {
                Console.WriteLine("Record Not Found");
            }


        }
        public void DeleteTM(IWebDriver driver)
        {

            //Delete existing record

            IWebElement findMyRecord1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            Thread.Sleep(2000);

            if (findMyRecord1.Text == "oldcode")
            {
                IWebElement deleteRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteRecord.Click();
                Thread.Sleep(2000);
                driver.SwitchTo().Alert().Accept();

                //check if the last page record has been deleted

                IWebElement goToLastPageBtn1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                goToLastPageBtn1.Click();
                Thread.Sleep(2000);

                if (goToLastPageBtn1.Text == "oldcode")

                {
                    Console.WriteLine("Delete Record not successful");
                    Thread.Sleep(2000);
                }

                else
                {
                    Console.WriteLine("Delete Record successful");
                }
            }

            else
            {
                Console.WriteLine("No Data found to Delete");
            }
        }

    }
    }


