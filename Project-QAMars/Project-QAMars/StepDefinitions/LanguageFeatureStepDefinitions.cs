using System;
using System.Reflection.Emit;
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
        LanguagePage LanguagePageObj;
        LoginPage LoginPageObj;

        public LanguageFeatureStepDefinitions()
        {
            LanguagePageObj = new LanguagePage();
            LoginPageObj = new LoginPage();
        }

        [Given(@"User is logged into localhost URL successfull")]
        public void GivenUserIsLoggedIntoLocalhostURLSuccessfull()
        {
            //Login page object initialization and definition
            LoginPageObj.LoginSteps();
        }

        [When(@"Adding new '([^']*)' and '([^']*)' to the language list")]
        public void WhenAddingNewAndToTheLanguageList(string language, string level)
        {
            //Adding new language to the language list
            LanguagePageObj.AddLanguage(language, level);
        }

        [Then(@"New record with '([^']*)' and '([^']*)' are added successfully")]
        public void ThenNewRecordWithAndAreAddedSuccessfully(string language, string level)
        {
            //Assertion of added languages
            string newLanguage = LanguagePageObj.getLanguage();
            string newLevel = LanguagePageObj.getLevel();
            Assert.AreEqual(language, newLanguage, "Actual language and expected language do not match.");
            Assert.AreEqual(level, newLevel, "Actual language level and expected language level do not match");
        }

        [Given(@"User is logged into localhost URL successfully")]
        public void GivenUserIsLoggedIntoLocalhostURLSuccessfully()
        {
            LoginPageObj.LoginSteps();
        }

        [When(@"Update '([^']*)' and '([^']*)' on an existing language record")]
        public void WhenUpdateAndOnAnExistingLanguageRecord(string language, string level)
        {
            //update an existing language in the language list  
            LanguagePageObj.UpdateLanguage(language, level);
        }

        [Then(@"The record should been updated '([^']*)' and '([^']*)' successfully")]
        public void ThenTheRecordShouldBeenUpdatedAndSuccessfully(string language, string level)
        {
            //Assertion of updated language
            string createdLanguage = LanguagePageObj.getEditedLanguage();
            string createdLevel = LanguagePageObj.getEditedLevel();
            Assert.AreEqual(language, createdLanguage, "Edited language and expected language do not match.");
            Assert.AreEqual(level, createdLevel, "Edited level and created level do not match");
        }

        [When(@"Delete the record '([^']*)' and '([^']*)' from the language list")]
        public void WhenDeleteTheRecordAndFromTheLanguageList(string language, string level)
        {
            //Delete the record from the language list
            LanguagePageObj.DeleteLanguage(language, level);
        }

        [Then(@"The record '([^']*)' and '([^']*)' should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully(string language, string level)
        {
            //Assertion of deleted language and level from the list
            string deletedElement = LanguagePageObj.GetDeletedElement();
            string deletedLevel = LanguagePageObj.GetDeletedLevel();

            Assert.AreNotEqual(language, deletedElement, "Deleted language and expected language does not match");
            Assert.AreNotEqual(level, deletedLevel, "Deleted leven and expected level does not match");
        }

    }
}
