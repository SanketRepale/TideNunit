using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using TideNunit.Hooks;

namespace TideNunit
{
    public class Tests : Hooks.BaseClass
    {
        [Test]

        public void SignUPPositive()
        {
            test = extents.CreateTest("SignUPPositive").Info("Test Started");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Launched URL Sucssesfully");
            Log.Information("Launched URL Sucssesfully");
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            test.Log(Status.Skip, "Closed Popup");
            driver.FindElement(By.XPath("//a[text()='Register']")).Click();
            int Scroll = driver.FindElement(By.XPath("//a[@href='https://www.facebook.com/Tide?fref=ts']")).Location.Y;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0," + Scroll + ")", "");
            driver.FindElement(By.XPath("//button[@class='sticker_close']")).Click();
            test.Log(Status.Skip, "Scroll down and Closed another Popup");
            driver.FindElement(By.XPath("//a[text()='Sign up now']")).Click();
            System.Collections.ObjectModel.ReadOnlyCollection<string> switchTabs = driver.WindowHandles;
            int count = switchTabs.Count;
            foreach (string tab in switchTabs)
            {
                driver.SwitchTo().Window(tab);
            }
            string path = @"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TestData.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var validFirstName = workbook.GetSheetAt(0).GetRow(2).GetCell(1).StringCellValue.Trim();
            var validEmail = workbook.GetSheetAt(0).GetRow(3).GetCell(1).StringCellValue.Trim();
            var validPass = workbook.GetSheetAt(0).GetRow(4).GetCell(1).StringCellValue.Trim();
            test.Log(Status.Debug, "Accesed deta from excel sheet");
            Log.Debug("Accesed deta from excel sheet and Entered Successfully");
            driver.FindElement(By.XPath("//input[@id='name']")).SendKeys(validFirstName);
            driver.FindElement(By.XPath("//input[@id='email']")).SendKeys(validEmail);
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys(validPass);
            driver.FindElement(By.XPath("//input[@value='CREATE ACCOUNT']")).Click();
            ((ITakesScreenshot)BaseClass.driver).GetScreenshot().SaveAsFile
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Screenshot\validSignup.png");
            test.Log(Status.Pass, "Executed Successfully");
            Log.Information("Executed successfully");
            driver.Quit();
        }
        [Test]

        public void SignUPNegative()
        {
            test = extents.CreateTest("SignUPNegative").Info("Test Started");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Launched URL Sucssesfully");
            Log.Information("Launched URL Sucssesfully");
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            test.Log(Status.Skip, "Closed Popup");
            driver.FindElement(By.XPath("//a[text()='Register']")).Click();
            int Scroll = driver.FindElement(By.XPath("//a[@href='https://www.facebook.com/Tide?fref=ts']")).Location.Y;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0," + Scroll + ")", "");
            driver.FindElement(By.XPath("//button[@class='sticker_close']")).Click();
            test.Log(Status.Skip, "Scroll down and Closed another Popup");
            driver.FindElement(By.XPath("//a[text()='Sign up now']")).Click();
            System.Collections.ObjectModel.ReadOnlyCollection<string> switchTabs = driver.WindowHandles;
            int count = switchTabs.Count;
            foreach (string tab in switchTabs)
            {
                driver.SwitchTo().Window(tab);
            }
            string path = @"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TestData.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var inValidFirstName = workbook.GetSheetAt(0).GetRow(7).GetCell(1).StringCellValue.Trim();
            var inValidEmail = workbook.GetSheetAt(0).GetRow(8).GetCell(1).StringCellValue.Trim();
            var inValidPass = workbook.GetSheetAt(0).GetRow(9).GetCell(1).StringCellValue.Trim();
            test.Log(Status.Debug, "Accesed deta from excel sheet");
            Log.Debug("Accesed deta from excel sheet and Entered Successfully");
            driver.FindElement(By.XPath("//input[@id='name']")).SendKeys(inValidFirstName);
            string firstName = driver.FindElement(By.XPath("//p[text()='First Name is invalid.']")).Text;
            string expectedFirstName = "First Name is invalid.";
            if (firstName == expectedFirstName)
            {
                Console.WriteLine("First Name is invalid.");
            }
            else
            {
                Console.WriteLine("Text is Not Present");
            }
            driver.FindElement(By.XPath("//input[@id='email']")).SendKeys(inValidEmail);
            string email = driver.FindElement(By.XPath("//p[text()='Email Not Valid']")).Text;
            string expectedEmail = "Email Not Valid";
            if (email == expectedEmail)
            {
                Console.WriteLine("Email Not Valid");
            }
            else
            {
                Console.WriteLine("Text is Not Present");
            }
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys(inValidPass);
            string pass = driver.FindElement(By.XPath("//p[text()='Password Must Contain Uppercase Letters']")).Text;
            string expectedPass = "Password Must Contain Uppercase Letters";
            if (pass == expectedPass)
            {
                Console.WriteLine("Password Must Contain Uppercase Letters");
            }
            else
            {
                Console.WriteLine("Text is Not Present");
            }
            driver.FindElement(By.XPath("//input[@value='CREATE ACCOUNT']")).Click();
            ((ITakesScreenshot)BaseClass.driver).GetScreenshot().SaveAsFile
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Screenshot\invalidSignup.png");
            test.Log(Status.Error, "Error message displayed after invalid data input Successfully");
            Log.Information("Error message displayed after invalid data input Successfully");
            driver.Quit();
        }
        [Test]
        public void PositiveLogin()
        {
            test = extents.CreateTest("PositiveLogin").Info("Test Started");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Launched URL Sucssesfully");
            Log.Information("Launched URL Sucssesfully");
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            driver.FindElement(By.XPath("//a[text()='Register']")).Click();
            int Scroll = driver.FindElement(By.XPath("//a[@href='https://www.facebook.com/Tide?fref=ts']")).Location.Y;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0," + Scroll + ")", "");
            driver.FindElement(By.XPath("//button[@class='sticker_close']")).Click();
            test.Log(Status.Debug, "closed popup Sucssesfully");
            driver.FindElement(By.XPath("//a[text()='Sign up now']")).Click();
            System.Collections.ObjectModel.ReadOnlyCollection<string> switchTabs = driver.WindowHandles;
            int count = switchTabs.Count;
            foreach (string tab in switchTabs)
            {
                driver.SwitchTo().Window(tab);
            }
            driver.FindElement(By.XPath("//button[text()='Log in']")).Click();
            string path = @"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TestData.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var validEmail = workbook.GetSheetAt(0).GetRow(3).GetCell(1).StringCellValue.Trim();
            var validPass = workbook.GetSheetAt(0).GetRow(4).GetCell(1).StringCellValue.Trim();
            driver.FindElement(By.XPath("//input[@id='login-email']")).SendKeys(validEmail);
            driver.FindElement(By.XPath("//input[@id='login-password']")).SendKeys(validPass);
            test.Log(Status.Debug, "Accesed deta from excel sheet");
            Log.Debug("Accesed deta from excel sheet and Entered Successfully");
            driver.FindElement(By.XPath("//input[@value='LOG IN']")).Click();
            ((ITakesScreenshot)BaseClass.driver).GetScreenshot().SaveAsFile
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Screenshot\validlogin.png");
            test.Log(Status.Pass, "Executed Successfully");
            Log.Information("Executed successfully");
            driver.Quit();
        }
        [Test]
        public void NegativeLogin()
        {
            test = extents.CreateTest("NegativeLogin").Info("Test Started");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Launched URL Sucssesfully");
            Log.Information("Launched URL Sucssesfully");
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            driver.FindElement(By.XPath("//a[text()='Register']")).Click();
            int Scroll = driver.FindElement(By.XPath("//a[@href='https://www.facebook.com/Tide?fref=ts']")).Location.Y;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0," + Scroll + ")", "");
            driver.FindElement(By.XPath("//button[@class='sticker_close']")).Click();
            test.Log(Status.Debug, "closed popup Sucssesfully");
            driver.FindElement(By.XPath("//a[text()='Sign up now']")).Click();
            System.Collections.ObjectModel.ReadOnlyCollection<string> switchTabs = driver.WindowHandles;
            int count = switchTabs.Count;
            foreach (string tab in switchTabs)
            {
                driver.SwitchTo().Window(tab);
            }
            driver.FindElement(By.XPath("//button[text()='Log in']")).Click();
            string path = @"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TestData.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var validEmail = workbook.GetSheetAt(0).GetRow(3).GetCell(1).StringCellValue.Trim();
            var inValidPass = workbook.GetSheetAt(0).GetRow(9).GetCell(1).StringCellValue.Trim();
            driver.FindElement(By.XPath("//input[@id='login-email']")).SendKeys(validEmail);
            driver.FindElement(By.XPath("//input[@id='login-password']")).SendKeys(inValidPass);
            driver.FindElement(By.XPath("//input[@value='LOG IN']")).Click();
            test.Log(Status.Debug, "Accesed deta from excel sheet");
            Console.WriteLine("Invalid Credentials");
            Log.Debug("Accesed deta from excel sheet and Entered Successfully");
            ((ITakesScreenshot)BaseClass.driver).GetScreenshot().SaveAsFile
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Screenshot\invalidlogin.png");
            test.Log(Status.Error, "Error message displayed after invalid data input Successfully");
            Log.Information("Error message displayed after invalid data input Successfully");
            driver.Quit();
        }
        [Test]
        public void ContactUs()
        {
            test = extents.CreateTest("ContactUs").Info("Test Started");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Launched URL Sucssesfully");
            Log.Information("Launched URL Sucssesfully");
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            driver.FindElement(By.XPath("//a[text()='Contact Us']")).Click();
            test.Log(Status.Pass, "Contact us Execued Sucssesfully");
            Log.Information("contact us Executed Sucssesfully");
            ((ITakesScreenshot)BaseClass.driver).GetScreenshot().SaveAsFile
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Screenshot\contactus.png");
            driver.Quit();

        }

        [Test]
        public void HowToWashCloths()
        {
            test = extents.CreateTest("HowToWashCloths").Info("Test Started");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Launched URL Sucssesfully");
            Log.Information("Launched URL Sucssesfully");
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            IWebElement element = driver.FindElement(By.XPath("//a[@data-action-detail='How to Wash Clothes']"));
            Actions act = new Actions(driver);
            act.MoveToElement(element);
            act.Perform();
            test.Log(Status.Info, "Clicked on the Option");
            Log.Information("Clicked on the Option");
            driver.FindElement(By.XPath("//span[text()='How to Remove Stains'][1]")).Click();
            driver.FindElement(By.XPath("//a[text()='Acne Cream']")).Click();
            string value = driver.FindElement(By.XPath("//h1[text()='How to Remove Acne Cream Stains']")).Text;
            string expected = "How to Remove Acne Cream Stains";
            if (value == expected)
            {
                Console.WriteLine("Text is Present");
            }
            else
            {
                Console.WriteLine("Text is Not Present");
            }
            ((ITakesScreenshot)BaseClass.driver).GetScreenshot().SaveAsFile
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Screenshot\HowToWashCloths.png");
            test.Log(Status.Info, "How to wash cloths Executed successesfully");
            Log.Information("How to wash cloths Executed successesfully");
            driver.Quit();
        }
        [Test]
        public void ShopProducts()
        {
            test = extents.CreateTest("ShopProducts").Info("Test Started");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Launched URL Sucssesfully");
            Log.Information("Launched URL Sucssesfully");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            IWebElement element = driver.FindElement(By.XPath("//a[@data-action-detail='Shop Products']"));
            Actions act = new Actions(driver);
            act.MoveToElement(element);
            act.Perform();
            driver.FindElement(By.XPath("//span[text()='Stain Removal'][1]")).Click();
            test.Log(Status.Debug, "Clicked on the product successfully");
            Log.Information("Clicked on the product successfully");
            driver.FindElement(By.XPath("//div[@ps-sku='030772032213'][1]")).Click();
            Log.Debug("Searched for Retailers sucessfully");
            driver.FindElement(By.XPath("//span[@class='ps-map-geolocation-button']")).Click();
            driver.FindElement(By.XPath("//span[text()='63 ct']")).Click();
            string value = driver.FindElement(By.XPath("//span[text()='FIND ONLINE']")).Text;
            string expected = "FIND ONLINE";
            if (value == expected)
            {
                Console.WriteLine("Text is Present");
            }
            else
            {
                Console.WriteLine("Text is Not Present");
            }
            ((ITakesScreenshot)BaseClass.driver).GetScreenshot().SaveAsFile
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Screenshot\ShopProducts.png");
            test.Log(Status.Info, "shop Products Executed successesfully");
            Log.Information("Shop Products Executed successesfully");
            driver.Quit();
        }
        [Test]
        public void WhatsNew()
        {
            test = extents.CreateTest("WhatsNew").Info("Test Started");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Launched URL Sucssesfully");
            Log.Information("Launched URL Sucssesfully");
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            driver.FindElement(By.XPath("//a[@data-action-detail='What’s New']")).Click();
            test.Log(Status.Info, "Read More option used successesfully");
            Log.Information("Read More option used successesfully");
            driver.FindElement(By.XPath("//a[@href='/en-us/shop/type/laundry-pods/tide-hygienic-clean-heavy-duty-10x-power-pods-free'][2]")).Click();
            string value = driver.FindElement(By.XPath("//h1[text()=' Heavy Duty 10X ']")).Text;
            string expected = "Heavy Duty 10X";
            if (value == expected)
            {
                Console.WriteLine("Information Related to the selected read more option is displayed sucessfully");
            }
            else
            {
                Console.WriteLine("Information Related to the selected read more option is not displayed sucessfully");
            }
            ((ITakesScreenshot)BaseClass.driver).GetScreenshot().SaveAsFile
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Screenshot\WhatsNew.png");
            test.Log(Status.Info, "WhatsNew Executed successesfully");
            Log.Information("WhatsNew Executed successesfully");
            driver.Quit();
        }
        [Test]
        public void CoupnsAndRewards()
        {
            test = extents.CreateTest("CoupnsAndRewards").Info("Test Started");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Launched URL Sucssesfully");
            Log.Information("Launched URL Sucssesfully");
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            driver.FindElement(By.XPath("//a[@data-action-detail='Coupons and Rewards']")).Click();
            driver.FindElement(By.XPath("//a[text()='Save Now']")).Click();
            System.Collections.ObjectModel.ReadOnlyCollection<string> switchTabs = driver.WindowHandles;
            int count = switchTabs.Count;
            foreach (string tab in switchTabs)
            {
                driver.SwitchTo().Window(tab);
            }
            Thread.Sleep(1000);
            string path = @"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TestData.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var validFirstName = workbook.GetSheetAt(0).GetRow(2).GetCell(1).StringCellValue.Trim();
            var validEmail = workbook.GetSheetAt(0).GetRow(3).GetCell(1).StringCellValue.Trim();
            var validPass = workbook.GetSheetAt(0).GetRow(4).GetCell(1).StringCellValue.Trim();
            test.Log(Status.Debug, "Accesed deta from excel sheet");
            Log.Debug("Accesed deta from excel sheet and Entered Successfully");
            driver.FindElement(By.XPath("//input[@id='name']")).SendKeys(validFirstName);
            driver.FindElement(By.XPath("//input[@id='email']")).SendKeys(validEmail);
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys(validPass);
            driver.FindElement(By.XPath("//input[@value='CREATE ACCOUNT']")).Click();
            ((ITakesScreenshot)BaseClass.driver).GetScreenshot().SaveAsFile
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Screenshot\couponsandrewards.png");
            test.Log(Status.Info, "Coupns and Rewards Executed successesfully");
            Log.Information("Coupns and Rewards Executed successesfully");
            driver.Quit();
        }
        [Test]
        public void searchBox()
        {
            test = extents.CreateTest("searchBox").Info("Test Started");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Launched URL Sucssesfully");
            Log.Information("Launched URL Sucssesfully");
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            driver.FindElement(By.XPath("//input[@type='search']")).SendKeys("Tide Ultra OXI Powder Laundry Detergent");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.XPath("//span[text()='Find Retailers'][1]")).Click();
            test.Log(Status.Info, "Searched the product successesfully");
            Log.Information("Searched the product successesfully");
            string outputText = driver.FindElement(By.XPath("//span[text()='FIND ONLINE']")).Text;
            string expectedText = "FIND ONLINE";
            if (outputText == expectedText)
            {
                Console.WriteLine("Text is Present");
            }
            else
            {
                Console.WriteLine("Text is Not Present");
            }
            ((ITakesScreenshot)BaseClass.driver).GetScreenshot().SaveAsFile
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Screenshot\searchbox.png");
            test.Log(Status.Info, "Search Box Verified successesfully");
            Log.Information("Search Box Verified successesfully");
            driver.Quit();
        }
        [Test]
        public void ChangeLanguage()
        {
            test = extents.CreateTest("ChangeLanguage").Info("Test Started");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            driver.Manage().Window.Maximize();
            test.Log(Status.Info, "Launched URL Sucssesfully");
            Log.Information("Launched URL Sucssesfully");
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            driver.FindElement(By.XPath("//button[text()='US - English']")).Click();
            driver.FindElement(By.XPath("//a[text()='US - Spanish']")).Click();
            test.Log(Status.Info, "Selected the page languagae needed successesfully");
            Log.Information("Selected the page languagae needed");
            string outputText = driver.FindElement(By.XPath("//span[text()='Parte de la familia de P&G']")).Text;
            string expectedText = "Parte de la familia de P&G";
            if (outputText == expectedText)
            {
                Console.WriteLine("langauge has been changed to US - Spanish");
            }
            else
            {
                Console.WriteLine("Text is Not Present");
            }
            ((ITakesScreenshot)BaseClass.driver).GetScreenshot().SaveAsFile
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Screenshot\changeLanguage.png");
            test.Log(Status.Info, "Change Language Verified successesfully");
            Log.Information("Change Language Verified successesfully");
            driver.Quit();
        }
    }
}