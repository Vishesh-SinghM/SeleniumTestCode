using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class Alerts
    {
        public IWebDriver driver;
        public void clickAlertTab()
        {
            driver.FindElement(By.XPath("//a[text()='Alert']")).Click();
        }

        public void clickOnSimpleAlertTab()
        {
            driver.FindElement(By.XPath("//a[text()='Simple Alert']")).Click();
        }
        
        public void clickOnAlertButton()
        {
            driver.FindElement(By.XPath("//button[text()='Click the button to display an alert box:']")).Click();
        }
        
        public void switchToAlertAndAccept()
        {
            driver.SwitchTo().Alert().Accept();
        }
        
        public void clickOnInputAlertTab()
        {
            driver.FindElement(By.XPath("//a[text()='Input Alert']")).Click();
        }

        public void clickOnInputAlertButton()
        {
            driver.FindElement(By.XPath("//button[text()='Click the button to demonstrate the Input box.']")).Click();
        }

        public void switchToInputAlertAndPerformAction()
        {
            driver.SwitchTo().Alert().Dismiss();
        }
    }

    public class AlertsExecution
    {
        static void Main(string[] args)
        {
            Alerts al = new Alerts();
            MouseDragabble md = new MouseDragabble();
            al.driver = md.driverInitialization();
            md.getUrl("https://www.way2automation.com/way2auto_jquery/draggable.php#load_box");
            Thread.Sleep(3000);

            al.clickAlertTab();
            al.clickOnSimpleAlertTab();
            Thread.Sleep(3000);
            md.switchToFrame(0);
            al.clickOnAlertButton();
            Thread.Sleep(2000);
            al.switchToAlertAndAccept();
            Thread.Sleep(2000);
            al.driver.SwitchTo().DefaultContent();
            al.clickOnInputAlertTab();
            Thread.Sleep(2000);
            md.switchToFrame(1);
            al.clickOnInputAlertButton();
            Thread.Sleep(2000);
            al.switchToInputAlertAndPerformAction();
        }
    }
}
