using Microsoft.Playwright;
using NUnit.Framework;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Pages;

public class NewWindowPage
{
    private IPage _page;
    private ScenarioContext _scenarioContext;
    public NewWindowPage(IPage page, ScenarioContext scenariocontext)
    {
        _page = page;
        _scenarioContext = scenariocontext;
    }

    private NewBrowserTabPage NewBrowserTabPage => new NewBrowserTabPage(_page, _scenarioContext);
    private ILocator NewBrowserTabText => _page.Locator("//div[@class='farme_window']//a");

    public async Task<string> GetTextFromNewTabOrWindow()
    {
        var text = await NewBrowserTabText.InnerTextAsync();
        return text;
    }

}