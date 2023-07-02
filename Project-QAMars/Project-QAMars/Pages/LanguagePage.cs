using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Project_QAMars.Utilities;
using SeleniumExtras.WaitHelpers;

namespace Project_QAMars.Pages
{
    public class LanguagePage : CommonDriver
    {
        //Adding New language to the language list
        public void AddLanguage(IWebDriver driver, string language, string level)
        {
            //Click on AddNew button
            IWebElement AddNew = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNew.Click();
            Thread.Sleep(1000);

            //Enter the language that needs to be added
            IWebElement AddLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            AddLanguageTextBox.SendKeys(language);
            Thread.Sleep(1000);

            //Choose the language level
            IWebElement ChooseLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            ChooseLanguageLevel.Click();
            ChooseLanguageLevel.SendKeys(level);
            Thread.Sleep(1000);

            //Click on Add button
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            AddButton.Click();
            Thread.Sleep(3000);
        }

        public string getLanguage(IWebDriver driver)
        {
            IWebElement newLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            return newLanguage.Text;
        }

        public string getLevel(IWebDriver driver)
        {
            IWebElement newLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            return newLevel.Text;

        }

        //Updating an already existing language in the language list 
        public void UpdateLanguage(IWebDriver driver, string language, string level)
        {
            //Click on pencilIcon
            IWebElement PencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            PencilIcon.Click();
            Thread.Sleep(1000);

            //Edit the language
            IWebElement UpdateLangauge = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            UpdateLangauge.Clear();
            UpdateLangauge.SendKeys(language);
            Thread.Sleep(1000);

            //Choose the level from the optional parameters
            IWebElement UpdateLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
            UpdateLevel.Click();
            UpdateLevel.SendKeys(level);
            Thread.Sleep(1000);

            //Click on Update button
            IWebElement UpdateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            UpdateButton.Click();
            Thread.Sleep(2000);

        }
        public string getEditedLanguage(IWebDriver driver)
        {
            IWebElement createdLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            return createdLanguage.Text;
        }

        public string getEditedLevel(IWebDriver driver)
        {
            IWebElement createdLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
            return createdLevel.Text;
        }

        //Deleting a language from the language list
        public void DeleteLanguage(IWebDriver driver, string language, string level)
        {
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));
            Thread.Sleep(2000);

            foreach (IWebElement row in rows)
            {
                // Get the text of the first column (language column) in the row
                IWebElement languageElement = row.FindElement(By.XPath("./td[1]"));
                IWebElement languageLevel = row.FindElement(By.XPath("./td[2]"));
                string languageText = languageElement.Text;
                string languageLevelText = languageLevel.Text;
                Thread.Sleep(2000);

                // Check if the language matches the provided text
                if (languageText.Equals(language, StringComparison.OrdinalIgnoreCase) && languageLevelText.Equals(level, StringComparison.OrdinalIgnoreCase))
                {
                    // Find and click the delete icon in the row
                    IWebElement deleteIcon = row.FindElement(By.XPath("./td[3]/span[2]/i"));
                    deleteIcon.Click();
                    Thread.Sleep(2000);
                    break;
                }
            }
        }
        public string GetDeletedElement(IWebDriver driver)
        {
            IWebElement deletedElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            return deletedElement.Text;
        }
        public string GetDeletedLevel(IWebDriver driver) 
        {
            IWebElement deletedLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
            return deletedLevel.Text;
        }

    }
}



    

