using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class MouseDragabble
    {
        public IWebDriver driver;
        public IWebDriver driverInitialization()
        {
          driver = new ChromeDriver();
          return driver;
        }

        public void getUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void switchToFrame(int x)
        {
            driver.SwitchTo().Frame(x);
        }

        public void mouseDraggable(string xpath)
        {
            IWebElement source = driver.FindElement(By.XPath(xpath));
            Actions a = new Actions(driver);
            a.DragAndDropToOffset(source, 0, 100).Build().Perform();
        }
        static void Main(string[] args)
        {
            MouseDragabble md = new MouseDragabble();
            md.driverInitialization();
            md.getUrl("https://www.way2automation.com/way2auto_jquery/draggable.php#load_box");
            Thread.Sleep(3000);
            md.switchToFrame(0);
            Thread.Sleep(3000);
            md.mouseDraggable("//p[text()='Drag me around']");

        }
    }
}
