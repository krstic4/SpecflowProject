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
    public class MultipleWindowsSteps
    {
        private readonly Driver _driver;
        private readonly ScenarioContext _scenarioContext;
        private MultipleWindowsPage MultipleWindowsPage => new MultipleWindowsPage(_driver.Page, _scenarioContext);
        private CommonFunctions CommonFunctions => new CommonFunctions(_driver.Page, _scenarioContext);
        private IPage NewWindow;
        public MultipleWindowsSteps(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
            _driver = (Driver)scenarioContext["Driver"];
        }

        [Then(@"I verify new windows are opened")]
        public async Task ThenIVerifyNewWindowsAreOpened()
        {
            await MultipleWindowsPage.GetAllWindowsOpened();
        }

        [Then(@"I close all windows which are not (.*)")]
        public async Task ThenICloseAllWindowsWhichAreNot(int window)
        {
            await MultipleWindowsPage.CloseAllWindowsExcept(window);
        }

        [Then(@"I close all window (.*) opened")]
        public async Task ThenICloseAllWindowOpened(int windowOpened)
        {
            await MultipleWindowsPage.CloseDesiredWindow(windowOpened);
        }


        [Then(@"I verify text in (.*) window is (.*)")]
        public async Task ThenIVerifyTextInWindowIsOpenWindow(int window, string expectedText)
        {

            NewWindow = await MultipleWindowsPage.GetPageForWindow(window);
            //NewWindow = (IPage)_scenarioContext[$"Page{window}"];
            var actualText = await MultipleWindowsPage.GetTextFromWindow(NewWindow);
            CommonFunctions.StringVerification(expectedText, actualText);
        }

        [When(@"I click in (.*) window on (.*)")]
        public async Task WhenIClickInWindowOn(int window, string text)
        {
            NewWindow = await MultipleWindowsPage.GetPageForWindow(window);
            //NewWindow = (IPage)_scenarioContext[$"Page{window}"];
            await MultipleWindowsPage.ClickOnTextInWindow(NewWindow);
        }

        [Then(@"I verify new window (.*) is opened")]
        public async Task ThenIVerifyNewWindowIsOpened(int window)
        {
            NewWindow = await MultipleWindowsPage.GetPageForWindow(window);
            await NewWindow.WaitForLoadStateAsync();
        }


        [When(@"I close all opened windows")]
        public async Task WhenICloseAllOpenedWindows()
        {
            await MultipleWindowsPage.CloseAllWindows();
        }


        [Then(@"I verify url in (.*) window is (.*)")]
        public async Task ThenIVerifyUrlInWindowIs(int window, string expectedUrl)
        {
            NewWindow = await MultipleWindowsPage.GetPageForWindow(window);
            //NewWindow = (IPage)_scenarioContext[$"Page{window}"];
            var actualUrl = MultipleWindowsPage.GetUrlFromWindow(NewWindow);
            CommonFunctions.StringVerification(expectedUrl, actualUrl);
        }

    }
}
