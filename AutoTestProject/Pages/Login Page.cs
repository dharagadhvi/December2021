using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestProject.Pages
{
    internal class LoginPage
    {
        public void LoginSteps(IWebDriver driver)

        {
       
        //Open chrome browser

        driver.Manage().Window.Maximize();


        //Launching turnup portalOpenQA.Selenium.NoSuchElementException has been thrown

        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

        //Indentyfy username tesxtbox and enter valid username

        IWebElement usernameTextBox = driver.FindElement(By.Id("UserName"));
        usernameTextBox.SendKeys("hari");



            //Identyfy Password textboxand enter valid password

        IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
        passwordTextBox.SendKeys("123123");

            //Click on login button

        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
        loginButton.Click();
            }

    }
}
