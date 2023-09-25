using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace TestOwO

{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver();
        }

        [Test]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl(@"https://localhost:7082/Login");
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("admin@rower.owo");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Admin!123");
            driver.FindElement(By.XPath("//button[@id='login-submit']")).Click();
            Assert.AreEqual(driver.Url, @"https://localhost:7082/");
        }

        [Test]
        public void AddReservationTest()
        {
            LoginTest();

            IList<IWebElement> rows = new List<IWebElement>();
            IList<IWebElement> rowsAfterCreate = new List<IWebElement>();

            driver.Navigate().GoToUrl(@"https://localhost:7082/Admin/Rentals");
            rows = driver.FindElements(By.XPath(@"//table[@class='table']//tbody/tr"));


            driver.Navigate().GoToUrl(@"https://localhost:7082/Users");
            driver.FindElement(By.Name("RentFrom")).SendKeys("01012050");
            driver.FindElement(By.Name("RentTill")).SendKeys("01012050");

            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            driver.Navigate().GoToUrl(@"https://localhost:7082/Admin/Rentals");
            rowsAfterCreate = driver.FindElements(By.XPath(@"//table[@class='table']//tbody/tr"));

            Assert.Greater(rowsAfterCreate.Count, rows.Count);
        }
    }
}