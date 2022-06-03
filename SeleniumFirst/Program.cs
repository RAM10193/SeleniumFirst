using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;

namespace SeleniumFirst
{
    
    class Program
    {
        IWebDriver dr = new ChromeDriver();
        SeleniumSetMethods setMethods = null;
        String agreebutton = "//button[contains(. ,'I agree')]";
        String textBox = "//span[contains(.,'Text Box')]";
       

        static void Main(String[] args)
        {

        }

        [SetUp]
        public void initialize()
        {
            dr.Navigate().GoToUrl("https://demoqa.com/elements");
            dr.Manage().Window.Maximize();
            if (dr.FindElements(By.XPath("//button[contains(. ,'I agree')]")).Count() > 0)
                setMethods.clickElement("xpath", agreebutton);
           
            Console.WriteLine("Browser launched");
        }
        
        [Test]
        public void action()
        {
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(10));
            if (dr.FindElements(By.XPath(textBox)).Count > 0)
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(textBox)));
                setMethods.clickElement("xpath", textBox);
            }
            else
                throw new NoSuchElementException();
            Console.WriteLine("Elements card clicked");
        }

        [TearDown]
        public void cleanup()
        {
            dr.Quit();
            Console.WriteLine("Browser closed");
        }
    }
}
