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
    public class FramesetSteps
    {
        private readonly Driver _driver;
        private readonly ScenarioContext _scenarioContext;
        private FramesetPage FrameSetPage => new FramesetPage(NewPage, _scenarioContext);
        private CommonFunctions CommonFunctions => new CommonFunctions(NewPage, _scenarioContext);
        private IPage NewPage;

        public FramesetSteps(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
            _driver = (Driver)scenarioContext["Driver"];
            NewPage = (IPage)_scenarioContext["newPage"];
        }

        [Then(@"I verify (.*) and (.*) frames are displayed")]
        public async Task ThenIVerifyAndFramesAreDisplayed(string frame1, string frame2)
        {
            await FrameSetPage.VerifyFramesAreDsiplayed(frame1, frame2);
        }

        [Then(@"I verify in (.*) frame Title is (.*)")]
        public async Task ThenIVerifyInFrameTitleIs(string frameNumber, string expectedTitle)
        {
            var actualTitle = await FrameSetPage.GetFrameTitleAsync(frameNumber);
            CommonFunctions.StringVerification(expectedTitle, actualTitle);
        }

        [Then(@"I verify in (.*) frame Content is matching")]
        public async Task ThenIVerifyInFrameContentIsMatching(string frameNumber)
        {
            var ExpectedFrameContent = FrameSetPage.GetExpectedFrameContent(frameNumber);
            var ActualFameContent = await FrameSetPage.GetFrameContentAsync(frameNumber);
            CommonFunctions.StringVerification(ExpectedFrameContent, ActualFameContent);
        }

        [When(@"I wait for frame to load")]
        public async Task WhenIWaitForFrameToLoad()
        {
            await NewPage.WaitForLoadStateAsync();
        }


    }
}
