using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Pages;

public class NewBrowserTabPage 
{
    private IPage _page;
    private ScenarioContext _scenarioContext;
    public NewBrowserTabPage(IPage page, ScenarioContext scenariocontext)
    {
        _page = page;
        _scenarioContext = scenariocontext;
    }

    private ILocator NewBrowserTabText => _page.Locator("//div[@class='farme_window']//a");
   

    public async Task<string> GetTextFromNewTabOrWindow()
    {
        var text = await NewBrowserTabText.InnerTextAsync();
        return text;
    }

}