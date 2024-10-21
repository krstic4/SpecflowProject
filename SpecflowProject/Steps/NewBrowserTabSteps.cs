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
    public class NewBrowserTabSteps
    {
        private readonly Driver _driver;
        private readonly ScenarioContext _scenarioContext;
        private NewBrowserTabPage NewBrowserTab => new NewBrowserTabPage(NewTab, _scenarioContext);
        private CommonFunctions CommonFunctions => new CommonFunctions(_driver.Page, _scenarioContext);
        private IPage NewTab;
        public NewBrowserTabSteps(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
            _driver = (Driver)scenarioContext["Driver"]; 
        }


        [Then(@"I verify new tab is opened with url (.*)")]
        public void ThenIVerifyNewTabIsOpened(string url)
        {
            //_newTab = await HomePage.GetFocusOnTab(url);
            NewTab = (IPage)_scenarioContext["newPage"];
            var actualUrl = NewTab.Url;
            CommonFunctions.StringVerification(url, actualUrl);
        }

        [Then(@"I verify (.*) text is displayed")]
        public async Task ThenIVerifTextIsDisplayed(string expectedText)
        {
            var actualText = await NewBrowserTab.GetTextFromNewTabOrWindow();
            CommonFunctions.StringVerification(expectedText, actualText);
        }

        [When(@"I close previously opened tab")]
        public async Task WhenIClosePreviouslyOpenedTab()
        {
            await NewTab.CloseAsync();
        }

    }
}
