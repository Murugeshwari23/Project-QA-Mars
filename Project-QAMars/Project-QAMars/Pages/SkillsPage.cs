using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Debugger;
using Project_QAMars.Utilities;
using TechTalk.SpecFlow;

namespace Project_QAMars.Pages
{
    public class SkillsPage : CommonDriver
    {
        private static IWebElement SkillsTab         => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private static IWebElement AddNew            => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement AddSkillTextBox   => driver.FindElement(By.Name("name"));
        private static IWebElement ChooseSkillLevel  => driver.FindElement(By.Name("level"));
        private static IWebElement AddButton         =>driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        private static IWebElement newSkill          => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement newSkillLevel     => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private static IWebElement UpdateSkillsTab   => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private static IWebElement PencilIcon        =>  driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private static IWebElement UpdateSkillTextBox=> driver.FindElement(By.Name("name"));
        private static IWebElement UpdateSkillLevel  => driver.FindElement(By.Name("level"));
        private static IWebElement UpdateButton      => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private static IWebElement newUpdatedSkill   => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement newUpdatedSkillLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement DeleteSkillsTab   => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private static IWebElement deleteIcon         => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
        private static IWebElement deletedSkillElement => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement deletedSkillLevel  => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));

        public void AddSkills(string skill, String skillLevel)
        {
            //Click on Skill tab
            SkillsTab.Click();
            ////Click on AddNew button
            AddNew.Click();
            //Enter the skills that needs to be added
            AddSkillTextBox.SendKeys(skill);
            //Choose the skill level
            ChooseSkillLevel.Click();
            ChooseSkillLevel.SendKeys(skillLevel);
            //Click onn Add button
            AddButton.Click();
            Thread.Sleep(2000);
        }
        public string getSkill()
        {
            return newSkill.Text;
        }
        public string getSkillLevel()
        {
            return newSkillLevel.Text;
        }
        public void UpdateSkills(string skill, string skillLevel)
        {
            //Click on Skill tab
            UpdateSkillsTab.Click();
            //Click on Pencil Icon
            PencilIcon.Click();
            //Update the skill
            UpdateSkillTextBox.Clear();
            UpdateSkillTextBox.SendKeys(skill);
            //Choose the level from the drop down
            UpdateSkillLevel.Click();
            UpdateSkillLevel.SendKeys(skillLevel);
            //Click on update button
            UpdateButton.Click();
            Thread.Sleep(2000);
        }
        public string getUpdatedSkill()
        {
       return newUpdatedSkill.Text;
        }
        public string getUpdatedSkillLevel()
        {
        return newUpdatedSkillLevel.Text;
        }

        //Deleting a Skill from the Skill list
        public void DeleteSkill(string skill, string skillLevel)
        {
            DeleteSkillsTab.Click();
            // Find and click the delete icon in the row
            deleteIcon.Click();
            Thread.Sleep(2000);                 
          }
        public string GetDeletedSkillElement()
        {
             return deletedSkillElement.Text;
        }
        public string GetDeletedSkillLevel()
        {
            return deletedSkillLevel.Text;
        }
    }
}
