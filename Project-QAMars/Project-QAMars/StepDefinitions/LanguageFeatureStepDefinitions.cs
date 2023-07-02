using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Project_QAMars.Pages;
using Project_QAMars.Utilities;
using TechTalk.SpecFlow;

namespace Project_QAMars.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        [Given(@"User is logged into localhost URL successfully")]
        public void GivenUserIsLoggedIntoLocalhostURLSuccessfully()
        {
            //Open chrome browser
            driver = new ChromeDriver();

            //Login page object initialization and defnition
            LoginPage LoginPageObj = new LoginPage();
            LoginPageObj.LoginSteps(driver);
        }

        [When(@"Navigate to language tab in the profile page")]
        public void WhenNavigateToLanguageTabInTheProfilePage()
        {
            //Clicking on Language tab button in the Home page
            ProfilePage ProfilePageObj = new ProfilePage();
            ProfilePageObj.GoToLanguageTab(driver);
        }

        [When(@"Add new '([^']*)' and '([^']*)' to the language list")]
        public void WhenAddNewAndToTheLanguageList(string language, string level)
        {   
            //Adding new language to the language list
            LanguagePage LanguagePageObj = new LanguagePage();
            LanguagePageObj.AddLanguage(driver, language, level);
        }

        [Then(@"New details '([^']*)' and '([^']*)' are added successfully")]
        public void ThenNewDetailsAndAreAddedSuccessfully(string language, string level)
        {
            //Assertion of added languages
            LanguagePage LanguagePageObj = new LanguagePage();

            string newLanguage = LanguagePageObj.getLanguage(driver);
            string newLevel = LanguagePageObj.getLevel(driver);

            Assert.AreEqual(language, newLanguage, "Actual language and expected language do not match.");
            Assert.AreEqual(level, newLevel, "Actual language level and expected language level do not match");

        }

        [When(@"Update '([^']*)' and '([^']*)' on an existing language record")]
        public void WhenUpdateAndOnAnExistingLanguageRecord(string language, string level)
        {
            //update an existing language in the language list
            LanguagePage LanguagePageObj = new LanguagePage();
            LanguagePageObj.UpdateLanguage(driver, language, level);
        }

        [Then(@"The record should been updated '([^']*)' and '([^']*)' successfully")]
        public void ThenTheRecordShouldBeenUpdatedAndSuccessfully(string language, string level)
        {
            //Assertion of updated languages
            LanguagePage LanguagePageObj = new LanguagePage();

            string createdLanguage = LanguagePageObj.getEditedLanguage(driver);
            string createdLevel = LanguagePageObj.getEditedLevel(driver);


            Assert.AreEqual(language, createdLanguage, "Edited language and expected language do not match.");
            Assert.AreEqual(level, createdLevel, "Edited level and created level do not match");
        }

        [When(@"Delete the record '([^']*)' and '([^']*)' from the language list")]
        public void WhenDeleteTheRecordAndFromTheLanguageList(string language, string level)
        {
            //Delete the record from the language list
            LanguagePage LanguagePageObj = new LanguagePage();
            LanguagePageObj.DeleteLanguage(driver, language, level);
        }

        [Then(@"The record '([^']*)' and '([^']*)' should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully(string language, string level)
        {
            LanguagePage LanguagePageObj = new LanguagePage();

            string deletedElement = LanguagePageObj.GetDeletedElement(driver);
            string deletedLevel = LanguagePageObj.GetDeletedLevel(driver);

            Assert.AreNotEqual(language, deletedElement, "Deleted language and expected language does not match");
            Assert.AreNotEqual(level, deletedLevel, "Deleted leven and expected level does not match");
        }
    
        [AfterScenario]
        public void closeTestRun()
        {
            driver.Quit();
        }
    }
}
