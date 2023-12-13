using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lab_5
{
    public class TestingWebPage
    {
        private IWebDriver page;
        private TestingPageElements testingPage;

        [SetUp]
        public void Setup()
        {
            page = new ChromeDriver();
            page.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            testingPage = new TestingPageElements(page);
            page.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/");
        }

        [TestCase("19", "21", "40")]
        [TestCase("97", "fgfd", "null")]
        [TestCase("83", "21,12", "null")]
        [TestCase("38", "0", "38")]
        [TestCase("4000000000000000000000", "512", "4e+21")]
        [TestCase("6800.782", "199.218", "7000")]
        [TestCase("-5481.75", "731.55", "-4750.2")]
        [TestCase("-16578.8431", "-421.1569", "-17000")]
        public void APlusBTest(string a, string b, string result)
        {
            testingPage.EnterValueA(a);
            testingPage.SelectOperation("+");
            testingPage.EnterValueB(b);

            Assert.AreEqual(result, testingPage.GetResult());
        }

        [TestCase("124", "23", "101")]
        [TestCase("1313", "%ij", "null")]
        [TestCase("29087", "517,80", "null")]
        [TestCase("548", "0", "548")]
        [TestCase("80000000000000000000000000000000000000", "13690", "8e+37")]
        [TestCase("43520.427", "520.327", "43000.100000000006")]
        [TestCase("-12372.086", "627.914", "-13000")]
        [TestCase("-517.5", "-67.25", "-450.25")]
        public void AMinusBTest(string a, string b, string result)
        {
            testingPage.EnterValueA(a);
            testingPage.SelectOperation("-");
            testingPage.EnterValueB(b);

            Assert.AreEqual(result, testingPage.GetResult());
        }

        [TestCase("12", "12", "144")]
        [TestCase("5780", "/(tu)", "null")]
        [TestCase("67431", "1217,0065", "null")]
        [TestCase("954", "0", "0")]
        [TestCase("9000000000000000000578374567263546000000000000", "8764466671182747476165241524617346876176321256564", "7.888020004064472e+94")]
        [TestCase("7690.271", "269.0012", "2068692.1273251998")]
        [TestCase("-15338.472", "1978.001", "-30339512.954471998")]
        [TestCase("-553.097", "-2284.741", "1263683.392877")]
        public void AMultiplyBTest(string a, string b, string result)
        {
            testingPage.EnterValueA(a);
            testingPage.SelectOperation("*");
            testingPage.EnterValueB(b);

            Assert.AreEqual(result, testingPage.GetResult());
        }

        [TestCase("546", "26", "21")]
        [TestCase("7318", "*fd!", "null")]
        [TestCase("18547", "341,2", "null")]
        [TestCase("725", "0", "null")]
        [TestCase("6000000000000000000000000000000000000000000000", "300000000000000000", "2e+28")]
        [TestCase("423857.5286", "728.1567", "582.0965852542454")]
        [TestCase("-690142.4017", "13778.2017", "-50.08943958920271")]
        [TestCase("-243.27", "-81.9", "2.9703296703296704")]
        public void ADivideBTest(string a, string b, string result)
        {
            testingPage.EnterValueA(a);
            testingPage.SelectOperation("/");
            testingPage.EnterValueB(b);

            Assert.AreEqual(result, testingPage.GetResult());
        }

        [Test]
        public void APlusBTestIncrementDecrement()
        {
            testingPage.EnterValueA("7");
            testingPage.DecrementA();
            testingPage.SelectOperation("+");
            testingPage.EnterValueB("0");
            testingPage.IncrementB();

            Assert.AreEqual("7", testingPage.GetResult());
        }

        [Test]
        public void AMinusBTestIncrementDecrement()
        {
            testingPage.EnterValueA("23");
            testingPage.DecrementA();
            testingPage.SelectOperation("-");
            testingPage.EnterValueB("9");
            testingPage.IncrementB();

            Assert.AreEqual("12", testingPage.GetResult());
        }

        [Test]
        public void AMultiplyBTestIncrementDecrement()
        {
            testingPage.EnterValueA("7");
            testingPage.DecrementA();
            testingPage.SelectOperation("*");
            testingPage.EnterValueB("2");
            testingPage.IncrementB();

            Assert.AreEqual("18", testingPage.GetResult());
        }

        [Test]
        public void ADivideBTestIncrementDecrement()
        {
            testingPage.EnterValueA("7");
            testingPage.DecrementA();
            testingPage.SelectOperation("/");
            testingPage.EnterValueB("2");
            testingPage.IncrementB();

            Assert.AreEqual("2", testingPage.GetResult());
        }

        [Test]
        public void NegativeAPlusBTestIncrementDecrement()
        {
            testingPage.EnterValueA("-15");
            testingPage.DecrementA();
            testingPage.SelectOperation("+");
            testingPage.EnterValueB("6");
            testingPage.IncrementB();

            Assert.AreEqual("-9", testingPage.GetResult());
        }

        [Test]
        public void NegativeAMinusBTestIncrementDecrement()
        {
            testingPage.EnterValueA("-16");
            testingPage.DecrementA();
            testingPage.SelectOperation("-");
            testingPage.EnterValueB("14");
            testingPage.IncrementB();

            Assert.AreEqual("-32", testingPage.GetResult());
        }

        [Test]
        public void NegativeAMultiplyBTestIncrementDecrement()
        {
            testingPage.EnterValueA("-12");
            testingPage.DecrementA();
            testingPage.SelectOperation("*");
            testingPage.EnterValueB("10");
            testingPage.IncrementB();

            Assert.AreEqual("-143", testingPage.GetResult());
        }

        [Test]
        public void NegativeADivideBTestIncrementDecrement()
        {
            testingPage.EnterValueA("-27");
            testingPage.DecrementA();
            testingPage.SelectOperation("/");
            testingPage.EnterValueB("1");
            testingPage.IncrementB();

            Assert.AreEqual("-14", testingPage.GetResult());
        }

        [Test]
        public void DecimalAPlusBTestIncrementDecrement()
        {
            testingPage.EnterValueA("4.27");
            testingPage.DecrementA();
            testingPage.SelectOperation("+");
            testingPage.EnterValueB("-2.17");
            testingPage.IncrementB();

            Assert.AreEqual("2.0999999999999996", testingPage.GetResult());
        }

        [Test]
        public void DecimalAMinusBTestIncrementDecrement()
        {
            testingPage.EnterValueA("8.76");
            testingPage.DecrementA();
            testingPage.SelectOperation("-");
            testingPage.EnterValueB("2.23");
            testingPage.IncrementB();

            Assert.AreEqual("4.529999999999999", testingPage.GetResult());
        }

        [Test]
        public void DecimalAMultiplyBTestIncrementDecrement()
        {
            testingPage.EnterValueA("-5.25");
            testingPage.DecrementA();
            testingPage.SelectOperation("*");
            testingPage.EnterValueB("-4");
            testingPage.IncrementB();

            Assert.AreEqual("18.75", testingPage.GetResult());
        }

        [Test]
        public void DecimalADivideBTestIncrementDecrement()
        {
            testingPage.EnterValueA("8.28");
            testingPage.DecrementA();
            testingPage.SelectOperation("/");
            testingPage.EnterValueB("6.07");
            testingPage.IncrementB();

            Assert.AreEqual("1.0297029702970295", testingPage.GetResult());
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
