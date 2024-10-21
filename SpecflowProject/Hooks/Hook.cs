using NUnit.Framework;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace SpecFlowProject1.Hooks
{
    [Binding]
    public class Hooks
    {
        private Driver? _driver;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            _driver = await Driver.CreateAsync();
            _scenarioContext["Driver"] = _driver;
        }

        [AfterScenario]
        public async Task TearDown()
        {
            if (_scenarioContext.TestError != null && _driver != null) 
            {
                var screenshotPath = $"{_scenarioContext.ScenarioInfo.Title}{DateTime.Now:yyyyMMdd_HHmmss}.png";
                await _driver.TakeScreenshotAsync(screenshotPath);
                Console.WriteLine($"Screenshot taken: {screenshotPath}");
            }

            if (_driver != null)
            {
                await _driver.DisposeAsync();
                _driver = null;
            }
        }
    }
}
