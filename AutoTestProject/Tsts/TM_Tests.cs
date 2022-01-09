using System;
using AutoTestProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoTestProject

{
    class TM_Tests
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();

            //Login Page object initialization and defination
            LoginPage loginPageobj = new LoginPage();
            loginPageobj.LoginSteps(driver);

            //Home Page object initialization and defination
            HomePage homePageobj = new HomePage();
            homePageobj.GoToTMPage(driver);

            //TM Page object initialization and defination
            TM_Page tM_Pageobj = new TM_Page();
            tM_Pageobj.Createtm(driver);

            //Edit TM
            tM_Pageobj.EditTM(driver);

            //Delete TM
            tM_Pageobj.DeleteTM(driver);

        }
    }
}

