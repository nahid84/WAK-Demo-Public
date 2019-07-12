using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTest
{
    [TestClass]
    public class ShowUserTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Inut()
        {
            driver = new ChromeDriver("./");
        }

        [TestCleanup]
        public void Close()
        {
            driver.Close();
        }

        [TestMethod]
        public void ShowTest_Show_Users()
        {
            driver.Url = "http://localhost:52180/users";
            IEnumerable<IWebElement> elements = driver.FindElements(By.TagName("a"));
            foreach (IWebElement element in elements)
            {
                if (element.GetAttribute("href").Equals("http://localhost:52180/transactions/NL09ABNA0444390669"))
                {
                    element.Click();
                    IEnumerable<IWebElement> webElements = driver.FindElements(By.XPath("//table[@class='table table-striped']//tbody/tr"));
                    var e = webElements.GetEnumerator();
                    e.MoveNext();
                    string s = e.Current.FindElement(By.TagName("td")).Text;
                    Assert.AreEqual(3, webElements.Count());
                    break;
                }

            }
        }

        [TestMethod]
        public void Create_User_Test()
        {
            driver.Url = "http://localhost:52180/create-user";
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.Click();
            firstName.SendKeys("Nahid_Test");

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.Click();
            lastName.SendKeys("Hasan_Test");

            IWebElement accountNumber = driver.FindElement(By.Id("accountNumber"));
            accountNumber.Click();
            accountNumber.SendKeys(Guid.NewGuid().ToString().Substring(0,10));

            IWebElement address = driver.FindElement(By.Id("address"));
            address.Click();
            address.SendKeys("Address_Test");

            IWebElement postcode = driver.FindElement(By.Id("postcode"));
            postcode.Click();
            postcode.SendKeys("Postcode_Test");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.Click();
            city.SendKeys("City_Test");

            IWebElement phone = driver.FindElement(By.Id("phone"));
            phone.Click();
            phone.SendKeys("Phone_Test");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.Click();
            email.SendKeys("Email_Test");

            IWebElement submit = driver.FindElement(By.ClassName("btn-success"));
            submit.Click();

            IWebElement createNew = driver.FindElement(By.ClassName("btn-success"));
            string s = createNew.Text;
            string s1 = createNew.GetAttribute("Value");
            Assert.Equals(s, "Create New");
        }
    }
}
