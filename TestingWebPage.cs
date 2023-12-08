using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lab_5
{
    [TestFixture]
    public class TestingWebPage
    {
        private IWebDriver page;
        private WebDriverWait webDriverWait;
        private TestingPageElements testingPage;

        [SetUp]
        public void Setup()
        {
            page = new ChromeDriver();
            webDriverWait = new WebDriverWait(page, TimeSpan.FromSeconds(10));
            testingPage = new TestingPageElements(page);
            page.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/");
        }

        [Test]
        public void NullAandBTest()
        {
            testingPage.EnterValueA("");
            testingPage.SelectOperation("+");
            testingPage.EnterValueB("");

            Assert.AreEqual("null", testingPage.GetResult());
        }

        [Test]
        public void ZeroAPlusBTest()
        {
            testingPage.EnterValueA("0");
            testingPage.SelectOperation("+");
            testingPage.EnterValueB("0");

            Assert.AreEqual("0", testingPage.GetResult());
        }

        [Test]
        public void ZeroAMinusBTest()
        {
            testingPage.EnterValueA("0");
            testingPage.SelectOperation("-");
            testingPage.EnterValueB("0");

            Assert.AreEqual("0", testingPage.GetResult());
        }

        [Test]
        public void ZeroAMultiplyBTest()
        {
            testingPage.EnterValueA("0");
            testingPage.SelectOperation("*");
            testingPage.EnterValueB("0");

            Assert.AreEqual("0", testingPage.GetResult());
        }

        [Test]
        public void ZeroADivideBTest()
        {
            testingPage.EnterValueA("0");
            testingPage.SelectOperation("/");
            testingPage.EnterValueB("0");

            Assert.AreEqual("null", testingPage.GetResult());
        }

        public void NotZeroAPlusBTest()
        {
            testingPage.EnterValueA("8");
            testingPage.SelectOperation("+");
            testingPage.EnterValueB("22");

            Assert.AreEqual("30", testingPage.GetResult());
        }

        [Test]
        public void NotZeroAMinusBTest()
        {
            testingPage.EnterValueA("90");
            testingPage.SelectOperation("-");
            testingPage.EnterValueB("18");

            Assert.AreEqual("72", testingPage.GetResult());
        }

        [Test]
        public void NotZeroAMultiplyBTest()
        {
            testingPage.EnterValueA("20");
            testingPage.SelectOperation("*");
            testingPage.EnterValueB("10");

            Assert.AreEqual("200", testingPage.GetResult());
        }

        [Test]
        public void NotZeroADivideBTest()
        {
            testingPage.EnterValueA("10");
            testingPage.SelectOperation("/");
            testingPage.EnterValueB("2");

            Assert.AreEqual("5", testingPage.GetResult());
        }

        public void NotZeroAPlusBTestIncrementDecrement()
        {
            testingPage.EnterValueA("7");
            testingPage.DecrementA();
            testingPage.SelectOperation("+");
            testingPage.EnterValueB("0");
            testingPage.IncrementB();

            Assert.AreEqual("6", testingPage.GetResult());
        }

        [Test]
        public void NotZeroAMinusBTestIncrementDecrement()
        {
            testingPage.EnterValueA("23");
            testingPage.DecrementA();
            testingPage.SelectOperation("-");
            testingPage.EnterValueB("9");
            testingPage.IncrementB();

            Assert.AreEqual("12", testingPage.GetResult());
        }

        [Test]
        public void NotZeroAMultiplyBTestIncrementDecrement()
        {
            testingPage.EnterValueA("7");
            testingPage.DecrementA();
            testingPage.SelectOperation("*");
            testingPage.EnterValueB("2");
            testingPage.IncrementB();

            Assert.AreEqual("18", testingPage.GetResult());
        }

        [Test]
        public void NotZeroADivideBTestIncrementDecrement()
        {
            testingPage.EnterValueA("7");
            testingPage.DecrementA();
            testingPage.SelectOperation("/");
            testingPage.EnterValueB("2");
            testingPage.IncrementB();

            Assert.AreEqual("2", testingPage.GetResult());
        }

        [Test]
        public void DivideZero()
        {
            testingPage.EnterValueA("17");
            testingPage.SelectOperation("/");
            testingPage.EnterValueB("0");

            Assert.AreEqual("null", testingPage.GetResult());
        }

        public void NegativePlusTestIncrementDecrement()
        {
            testingPage.EnterValueA("-15");
            testingPage.DecrementA();
            testingPage.SelectOperation("+");
            testingPage.EnterValueB("6");
            testingPage.IncrementB();

            Assert.AreEqual("-7", testingPage.GetResult());
        }

        [Test]
        public void NegativeMinusTestIncrementDecrement()
        {
            testingPage.EnterValueA("-16");
            testingPage.DecrementA();
            testingPage.SelectOperation("-");
            testingPage.EnterValueB("14");
            testingPage.IncrementB();

            Assert.AreEqual("-30", testingPage.GetResult());
        }

        [Test]
        public void NegativeMultiplyTestIncrementDecrement()
        {
            testingPage.EnterValueA("-12");
            testingPage.DecrementA();
            testingPage.SelectOperation("*");
            testingPage.EnterValueB("10");
            testingPage.IncrementB();

            Assert.AreEqual("-121", testingPage.GetResult());
        }

        [Test]
        public void NegativeDivideTestIncrementDecrement()
        {
            testingPage.EnterValueA("-27");
            testingPage.DecrementA();
            testingPage.SelectOperation("/");
            testingPage.EnterValueB("1");
            testingPage.IncrementB();

            Assert.AreEqual("-13", testingPage.GetResult());
        }

        public void DecimalPlusTestIncrementDecrement()
        {
            testingPage.EnterValueA("4.27");
            testingPage.DecrementA();
            testingPage.SelectOperation("+");
            testingPage.EnterValueB("-2.17");
            testingPage.IncrementB();

            Assert.AreEqual("0.1", testingPage.GetResult());
        }

        [Test]
        public void DecimalMinusTestIncrementDecrement()
        {
            testingPage.EnterValueA("8.76");
            testingPage.DecrementA();
            testingPage.SelectOperation("-");
            testingPage.EnterValueB("2.23");
            testingPage.IncrementB();

            Assert.AreEqual("10.99", testingPage.GetResult());
        }

        [Test]
        public void DecimalMultiplyTestIncrementDecrement()
        {
            testingPage.EnterValueA("-5.25");
            testingPage.DecrementA();
            testingPage.SelectOperation("*");
            testingPage.EnterValueB("-4");
            testingPage.IncrementB();

            Assert.AreEqual("21.25", testingPage.GetResult());
        }

        [Test]
        public void DecimalDivideTestIncrementDecrement()
        {
            testingPage.EnterValueA("8.28");
            testingPage.DecrementA();
            testingPage.SelectOperation("/");
            testingPage.EnterValueB("6.07");
            testingPage.IncrementB();

            Assert.AreEqual("-1.02", testingPage.GetResult());
        }

        [TearDown]
        public void TearDown()
        {
            page.Quit();
        }
    }

    public class TestingPageElements
    {
        private IWebDriver page;

        private IWebElement ValueAInput => page.FindElement(By.XPath("//input[@ng-model='a']"));
        private IWebElement ValueBInput => page.FindElement(By.XPath("//input[@ng-model='b']"));
        private IWebElement IncrementAButton => page.FindElement(By.XPath("//button[@ng-click='inca()']"));
        private IWebElement DecrementAButton => page.FindElement(By.XPath("//button[@ng-click='deca()']"));
        private IWebElement IncrementBButton => page.FindElement(By.XPath("//button[@ng-click='incb()']"));
        private IWebElement DecrementBButton => page.FindElement(By.XPath("//button[@ng-click='decb()']"));
        private IWebElement OperationSelect => page.FindElement(By.XPath("//select[@ng-model='operation']"));
        private IWebElement CalculateButton => page.FindElement(By.XPath("//button[@class='command']"));
        private IWebElement Result => page.FindElement(By.XPath("//b[contains(@class, 'result')]"));

        public TestingPageElements(IWebDriver page)
        {
            this.page = page;
        }

        public void EnterValueA(string value)
        {
            ValueAInput.Clear();
            ValueAInput.SendKeys(value);
        }

        public void EnterValueB(string value)
        {
            ValueBInput.Clear();
            ValueBInput.SendKeys(value);
        }

        public void IncrementA()
        {
            IncrementAButton.Click();
        }

        public void DecrementA()
        {
            DecrementAButton.Click();
        }

        public void IncrementB()
        {
            IncrementBButton.Click();
        }

        public void DecrementB()
        {
            DecrementBButton.Click();
        }

        public void SelectOperation(string operation)
        {
            var select = new SelectElement(OperationSelect);
            select.SelectByText(operation);
        }


        public string GetResult()
        {
            string resultText = Result.Text;
            string[] parts = resultText.Split('=');
            string numericResult = parts[1].Trim();
            return numericResult;
        }
    }
}
