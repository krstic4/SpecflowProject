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
    public class HomeSteps
    {
        private readonly Driver _driver;
        private readonly ScenarioContext _scenarioContext;
        private static string BaseUrl = "https://www.way2automation.com/way2auto_jquery/frames-and-windows.php#load_box";
        private CommonFunctions CommonFunctions => new CommonFunctions(_driver.Page, _scenarioContext);
        private HomePage HomePage => new HomePage(_driver.Page, _scenarioContext);

        public HomeSteps(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
            _driver = (Driver)scenarioContext["Driver"];
        }

        [Given(@"I navigate to application via url")]
        public async Task GivenINavigateToApplicationViaUrl()
        {
            await _driver.Page.GotoAsync(BaseUrl);
            await _driver.Page.WaitForLoadStateAsync();
        }

        [When(@"I click on (.*) tab")]
        public async Task WhenIClickOnTab(string tab)
        {
            await HomePage.ClickNavigationBar(tab);
        }

        [When(@"I get text from (.*) frame")]
        public async Task WhenIGetTextFromFrame(string frameName)
        {
            var actualText = await HomePage.GetTextFromFrame(frameName);
           _scenarioContext.Add("textFromFrame", actualText);
        }

        [Then(@"I verify text from frame is equal to (.*)")]
        public void ThenIVerifyTextFromFrameIsEqualTo(string expectedText)
        {
            var actualText = _scenarioContext["textFromFrame"].ToString();
            CommonFunctions.StringVerification(expectedText, actualText);
        }

        [Then(@"I click on (.*) in Frame")]
        [When(@"I click on (.*) in Frame")]
        public async Task WhenIClickOnInFrame(string textInFrame)
        {
            var newPageTask = _driver.Page.Context.WaitForPageAsync();
            await HomePage.ClickOnTextInFrame(textInFrame);
            try
            {
                var newPage = await newPageTask;
                if (_scenarioContext.ContainsKey("newPage")) _scenarioContext.Remove("newPage");
                _scenarioContext["newPage"] = newPage;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine("Timeout exception is being thrown while trying to await for new Page!" +
                    $"Exception log:'{e.Message}'");
                throw;
            }
        }

        [Then(@"I verify home page is displayed")]
        public async Task ThenIVerifyHomePageIsDisplayed()
        {
            await HomePage.VerifyNavBarIsDisplayed();
        }



    }
}
