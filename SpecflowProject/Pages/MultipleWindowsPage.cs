using Microsoft.Playwright;
using NUnit.Framework;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Pages;

public class MultipleWindowsPage
{
    private IPage _page;
    private ScenarioContext _scenarioContext;
    public MultipleWindowsPage(IPage page, ScenarioContext scenariocontext)
    {
        _page = page;
        _scenarioContext = scenariocontext;
    }

    private ILocator NewWindowText(IPage page) => page.Locator("//div[@class='farme_window']//a");
    public async Task GetAllWindowsOpened()
    {
        var windowCount = 0;
        await Task.Delay(1000);
        var allPages = new List<IPage>(_page.Context.Pages);
        foreach (var window in allPages)
        {
            _scenarioContext["Page" + windowCount] = window;
            var windowOpened = (IPage)_scenarioContext[$"Page{windowCount}"];
            _scenarioContext["NumberOfOpenedWindows"] = windowCount;
            windowCount++;
        }
    }

    public async Task CloseAllWindowsExcept(int openWindow)
    {
        var windowCount = 0;
        await Task.Delay(1000);
        var allPages = new List<IPage>(_page.Context.Pages);
        foreach (var window in allPages)
        {
            _scenarioContext["Page" + windowCount] = window;
            var windowOpened = (IPage)_scenarioContext[$"Page{windowCount}"];
            if (windowCount != openWindow && windowCount != 0) await windowOpened.CloseAsync();
            windowCount++;
        }
    }

    public async Task CloseAllWindows()
    {
        var windowCount = 0;
        await Task.Delay(1000);
        var allPages = new List<IPage>(_page.Context.Pages);
        foreach (var window in allPages)
        {
            _scenarioContext["Page" + windowCount] = window;
            var windowOpened = (IPage)_scenarioContext[$"Page{windowCount}"];
            if (windowCount != 0) await windowOpened.CloseAsync();
            windowCount++;
        }
    }

    public async Task<string> GetTextFromWindow(IPage page)
    {
        var text = await NewWindowText(page).InnerTextAsync();
        return text;
    }

    public async Task ClickOnTextInWindow(IPage page)
    {
        await NewWindowText(page).ClickAsync();
    }

    public string GetUrlFromWindow(IPage page)
    {
        var url = page.Url;
        return url;
    }
}