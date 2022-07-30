using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace TideNunit.Hooks
{
    public class BaseClass
    {
        public static IWebDriver driver;
        public static ExtentReports extents = null;
        public static ExtentTest test = null;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extents = new ExtentReports();
            var htmlReport = new ExtentHtmlReporter
                (@"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Reports\index.html");
            extents.AttachReporter(htmlReport);
            LoggingLevelSwitch loggingLevel = new LoggingLevelSwitch(LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration().MinimumLevel.ControlledBy(levelSwitch: loggingLevel).WriteTo.File(
                @"C:\Users\mindc1may74\Desktop\M1089040 Comprehensive Assesment\Automation Using NUnit And BDD\TideNunit\TideNunit\Reports\Logs",
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}").CreateLogger();
        }
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extents.Flush();
        }
    }
}
