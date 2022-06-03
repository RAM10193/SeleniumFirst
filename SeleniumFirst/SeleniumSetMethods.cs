using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst
{
    public class SeleniumSetMethods
    {
        public IWebDriver dr;
        public void seleniumSetMethods(IWebDriver driver)
        {
            this.dr = driver; 
              
        }
        public void typeText(String elementType, String locator, String value)
        {
            if (elementType.ToLower() == "id")
                dr.FindElement(By.Id(locator)).SendKeys(value);
            else if (elementType.ToLower() == "name")
                dr.FindElement(By.Id(locator)).SendKeys(value);
            else if (elementType.ToLower() == "Xpath")
                dr.FindElement(By.Id(locator)).SendKeys(value);
            else
                throw new ElementNotVisibleException();
        }

        public void clickElement(String elementType, String locator)
        {
            try {
            if (elementType.ToLower() == "id")
                dr.FindElement(By.Id(locator)).Click();
            else if (elementType.ToLower() == "name")
                dr.FindElement(By.Id(locator)).Click();
            else if (elementType.ToLower() == "xpath")
                dr.FindElement(By.Id(locator)).Click();
            }
            catch 
            {
                throw new ElementClickInterceptedException();
            }
             
        }


        public void SelectvaluesDropdown(String elementType, String locator, String value)
        {

             if (elementType == "id")
                new SelectElement(dr.FindElement(By.Id(locator))).SelectByValue(value);
            else if (elementType == "name")
                new SelectElement(dr.FindElement(By.Id(locator))).SelectByValue(value);
            else if (elementType == "Xpath")
                new SelectElement(dr.FindElement(By.Id(locator))).SelectByValue(value);
            else
                throw new ElementClickInterceptedException();
        }

    }
}
