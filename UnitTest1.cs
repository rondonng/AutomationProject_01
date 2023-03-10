using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationProject_01
{
    
    public class Tests
    {
        //Instancia de 
        public IWebDriver driver = new ChromeDriver();
        public IWebElement elementName;
        //Instancia de la url
        public string url = "https://automationexercise.com/login";
        //Instancia de los XPath de los elementos de signup
        public string signupNameXPath = "//input[@data-qa='signup-name']";
        public string signupEmailXPath = "//input[@data-qa='signup-email']";
        public string signupButtonXPath = "//button[@data-qa='signup-button']";

        [SetUp]
        public void Setup()
        {
            //Ir al sitio web
            driver.Navigate().GoToUrl(url);
            //Maximizar la ventana del sitio web
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test_001_SignupElementsValidation()
        {            
            //Validando que el signupName este presente
            elementName = driver.FindElement(By.XPath(signupNameXPath));
            bool signupNameValidation = elementName.Displayed;
            //Validando que el signupEmail este presente
            elementName = driver.FindElement(By.XPath(signupEmailXPath));
            bool signupEmailValidation = elementName.Displayed;
            //Validando que el signupButton este presente
            elementName = driver.FindElement(By.XPath(signupButtonXPath));
            bool signupButtonValidation = elementName.Displayed;
            //Validacion final
            bool finalValidation = (signupNameValidation && signupEmailValidation && signupButtonValidation);
            //Mostrar por consola el resultado final de la validación
            Console.WriteLine("Resultado final = " + finalValidation);
            //Assertion final
            Assert.IsTrue(finalValidation);
        }
        [Test]
        public void Test_002_SignUp()
        {
            driver.FindElement(By.XPath(signupNameXPath)).SendKeys("Pedro");
            driver.FindElement(By.XPath(signupEmailXPath)).SendKeys("pedro32123@gmail.com");
            driver.FindElement(By.XPath(signupButtonXPath)).Click();
            elementName = driver.FindElement(By.XPath("//div[@class='login-form']/h2/b"));
            bool validation = elementName.Displayed;
            Console.WriteLine("Resultado final = " + validation);
            Assert.IsTrue(validation);
        }    
        [TearDown]
        public void QuitPage()
        { 
            //driver.Close();
        }

    }
}