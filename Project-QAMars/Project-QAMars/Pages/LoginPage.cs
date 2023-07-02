using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Project_QAMars.Pages
{
    public class LoginPage
    {
        public void LoginSteps (IWebDriver driver)
        {
            // launch localhost 
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            // enter valid username in the username field
            IWebElement SignInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            SignInButton.Click();
            Thread.Sleep(1000);

            // enter valid credentials email and password
            IWebElement Email = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            Email.SendKeys("ammu.muru279@gmail.com");
            Thread.Sleep(1000);

            IWebElement Password = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            Password.SendKeys("mvp123");
            Thread.Sleep(1000);

            IWebElement RememberMe = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div/input"));
            RememberMe.Click();
            Thread.Sleep(1000);

            // click login button
            IWebElement loginbutton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginbutton.Click();
            Thread.Sleep(2000);

        }

    }
}
