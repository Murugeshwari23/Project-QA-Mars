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
        private static IWebElement AddNew               => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement AddLanguageTextBox   => driver.FindElement(By.Name("name"));
        private static IWebElement ChooseLanguageLevel  => driver.FindElement(By.Name("level"));
        private static IWebElement AddButton            => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        private static IWebElement newLanguage          => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement newLevel             => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private static IWebElement PencilIcon           => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private static IWebElement UpdateLangauge       => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        private static IWebElement UpdateLevel          => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
        private static IWebElement UpdateButton         => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private static IWebElement createdLanguage      => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement createdLevel         => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement deletedElement       => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement deletedLevel         => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));


        //Adding New language to the language list
        public void AddLanguage(string language, string level)
        {
            //Click on AddNew button
            AddNew.Click();
            //Enter the language that needs to be added
            AddLanguageTextBox.SendKeys(language);
            //Choose the language level
            ChooseLanguageLevel.Click();
            ChooseLanguageLevel.SendKeys(level);
            //Click on Add button
            AddButton.Click();
            Thread.Sleep(2000);
        }
        public string getLanguage()
        {
            return newLanguage.Text;
        }

        public string getLevel()
        {
            return newLevel.Text;

        }

        //Updating an already existing language in the language list 
        public void UpdateLanguage(string language, string level)
        {
            //Click on pencilIcon
            PencilIcon.Click();
            //Edit the language
            UpdateLangauge.Clear();
            UpdateLangauge.SendKeys(language);
           //Choose the level from the drop down
            UpdateLevel.Click();
            UpdateLevel.SendKeys(level);
            //Click on Update button
            UpdateButton.Click();
            Thread.Sleep(2000);
        }
        public string getEditedLanguage()
        {
             return createdLanguage.Text;
        }

        public string getEditedLevel()
        {
             return createdLevel.Text;
        }

        //Deleting a language from the language list
        public void DeleteLanguage(string language, string level)
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
                Thread.Sleep(1000);

                // Check if the language matches the provided text
                if (languageText.Equals(language, StringComparison.OrdinalIgnoreCase) && languageLevelText.Equals(level, StringComparison.OrdinalIgnoreCase))
                {
                    // Find and click the delete icon in the row
                    IWebElement deleteIcon = row.FindElement(By.XPath("./td[3]/span[2]/i"));
                    deleteIcon.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }
        }
        public string GetDeletedElement()
        {
            return deletedElement.Text;
        }
        public string GetDeletedLevel() 
        {
            return deletedLevel.Text;
        }
    }
}



    

