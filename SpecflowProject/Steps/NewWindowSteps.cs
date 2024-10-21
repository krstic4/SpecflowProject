using Microsoft.Playwright;
using NUnit.Framework;
using SpecflowProject.Pages;
using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class NewWindowSteps
    {
        private readonly Driver _driver;
        private readonly ScenarioContext _scenarioContext;
        private HomePage HomePage => new HomePage(_driver.Page, _scenarioContext);
        private NewWindowPage NewWindowPage => new NewWindowPage(NewPage, _scenarioContext);
        private CommonFunctions CommonFunctions => new CommonFunctions(_driver.Page, _scenarioContext);
        private IPage NewPage;

        public NewWindowSteps(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
            _driver = (Driver)scenarioContext["Driver"];
            NewPage = (IPage)_scenarioContext["newPage"];
        }

        [Then(@"I verify new window is opened via url (.*)")]
        public void ThenIVerifyNewWindowIsOpenedViaUrl(string expectedUrl)
        {
            var actualUrl = NewPage.Url;
            Assert.That(expectedUrl.Equals(actualUrl), $"Url's are not equal! Expected:'{expectedUrl}' and actual url is: '{actualUrl}'");
        }

        [Then(@"I verify (.*) is displayed in new window")]
        public async Task ThenIVerifyIsDisplayedInNewWindow(string expectedUrl)
        {
            var actualUrl = await NewWindowPage.GetTextFromNewTabOrWindow();
            CommonFunctions.VerifyUrl(expectedUrl, actualUrl);
        }

        [When(@"I close previously opened window")]
        public async Task WhenIClosePreviouslyOpenedWindow()
        {
            await NewPage.CloseAsync();
        }
    }
}
