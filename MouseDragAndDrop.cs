using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class MouseDragAndDrop
    {
        public IWebDriver driver;

        public void clickOnInteractionTab()
        {
            driver.FindElement(By.XPath("//a[text()='Interaction']")).Click();
        }

        public void clickOnDroppableOption()
        { 
            driver.FindElement(By.XPath("//a[text()='Droppable']")).Click();
        }

        public void mouseDragAndDrop(string xpath1,string xpath2)
        {
            IWebElement source = driver.FindElement(By.XPath(xpath1));
            IWebElement target = driver.FindElement(By.XPath(xpath2));
            Actions a = new Actions(driver);
            a.DragAndDrop(source,target).Build().Perform();
        }

        public void clickOnAcceptTab()
        {
            driver.FindElement(By.XPath("//a[text()='Accept']")).Click();
        }

        public void clickOnPreventPropagationTab()
        {
            driver.FindElement(By.XPath("//a[text()='Prevent propagation']")).Click();
        }

        public void clickOnRevertDraggablePosition()
        {
            driver.FindElement(By.XPath("//a[text()='Revert draggable Position']")).Click();
        }



    }

    public class MouseDragAndDropExecution

    {
        static void Main(string[] args)
        {
            MouseDragAndDrop mdd = new MouseDragAndDrop();
            MouseDragabble md = new MouseDragabble();
            mdd.driver = md.driverInitialization();
            md.getUrl("https://www.way2automation.com/way2auto_jquery/draggable.php#load_box");
            mdd.clickOnInteractionTab();
            Thread.Sleep(2000);
            mdd.clickOnDroppableOption();
            md.switchToFrame(0);
            mdd.mouseDragAndDrop("//p[text()='Drag me to my target']", "//p[text()='Drop here']");
            mdd.driver.SwitchTo().DefaultContent();
            mdd.clickOnAcceptTab();
            md.switchToFrame(1);
            md.mouseDraggable("//p[contains(text(),\"I'm draggable but can't be dropped\")]");
            mdd.mouseDragAndDrop("//p[text()='Drag me to my target']", "//p[contains(text(),\"accept: '#draggable'\")]");
            mdd.driver.SwitchTo().DefaultContent();
            mdd.clickOnPreventPropagationTab();
            md.switchToFrame(2);
            mdd.mouseDragAndDrop("//p[contains(text(),'Drag me to my target')]","//p[contains(text(),'Outer droppable')]");
            mdd.mouseDragAndDrop("//p[contains(text(),'Drag me to my target')]", "//p[contains(text(),'Inner droppable')]");
            mdd.mouseDragAndDrop("//p[contains(text(),'Drag me to my target')]", "//p[contains(text(),'Outer droppable')]");
            mdd.mouseDragAndDrop("//p[contains(text(),'Drag me to my target')]", "//p[contains(text(),'Inner droppable')]");
            mdd.driver.SwitchTo().DefaultContent();
            mdd.clickOnRevertDraggablePosition();
            md.switchToFrame(3);
            md.mouseDraggable("//p[contains(text(),\"I revert when I'm dropped\")]");
            mdd.mouseDragAndDrop("//p[contains(text(),\"I revert when I'm dropped\")]", "//p[contains(text(),'Drop me here')]");
            Thread.Sleep(3000);
            md.mouseDraggable("//p[contains(text(),\"I revert when I'm not dropped\")]");
            
            }

    }
    
}
