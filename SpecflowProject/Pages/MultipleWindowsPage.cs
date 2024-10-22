using Microsoft.Playwright;
using NUnit.Framework;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;
using static System.Net.WebRequestMethods;

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
            if (_scenarioContext.ContainsKey($"Page{windowCount}")) _scenarioContext.Remove($"Page{windowCount}");
            _scenarioContext[$"Page{windowCount}"] = window;
            var windowOpened = (IPage)_scenarioContext[$"Page{windowCount}"];
            _scenarioContext["NumberOfOpenedWindows"] = windowCount;
            windowCount++;
        }
    }

    public string ReturnWindowUrlBasedOnIndex(int index)
    {
        var url = string.Empty;
        switch(index)
        {
            case 1:
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window1.html";
                break;
            case 11:
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window1.html#";
                break;
            case 2:
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window2.html";
                break;
            case 22:
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window2.html#";
                break;
            case 3:
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window3.html";
                break;
            case 33:
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window3.html#";
                break;
            default:
                throw new NotImplementedException($"Index: {index} was not found in switch case options while trying to get window url!");
        }
        return url;
    }

    public async Task CloseDesiredWindow(int desiredWindow)
    {
        var pageUrl = ReturnWindowUrlBasedOnIndex(desiredWindow);
        var pageUrl2 = ReturnWindowUrlBasedOnIndex(desiredWindow) + "#";
        await Task.Delay(1000);
        var allPages = new List<IPage>(_page.Context.Pages);
        foreach(var window in allPages)
        {
            if (window.Url.Equals(pageUrl)) await window.CloseAsync();
            if (window.Url.Equals(pageUrl2)) await window.CloseAsync();
        }
    }

    public async Task<IPage> GetPageForWindow(int desiredWindow)
    {
        var pageUrl = ReturnWindowUrlBasedOnIndex(desiredWindow);
        await Task.Delay(1000);
        var allPages = new List<IPage>(_page.Context.Pages);
        foreach (var window in allPages)
        {
            if (window.Url.Equals(pageUrl)) return window;
        }
        return null;
    }

    public async Task CloseAllWindowsExcept(int openWindow)
    {
        var windowCount = 0;
        await Task.Delay(1000);
        var allPages = new List<IPage>(_page.Context.Pages);
        foreach (var window in allPages)
        {
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