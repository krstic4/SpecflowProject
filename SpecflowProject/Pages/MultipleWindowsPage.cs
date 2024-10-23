using Microsoft.Playwright;
using NUnit.Framework;
using SpecflowProject.Pages;
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
    private CommonFunctions CommonFunctions => new CommonFunctions(_page, _scenarioContext);

    public async Task GetAllWindowsOpened()
    {
        await CommonFunctions.WaitForAllPagesToBeReadyAsync(_page);
        var windowCount = 0;
        var allPages = new List<IPage>(_page.Context.Pages);
        foreach (var window in allPages)
        {
            if (_scenarioContext.ContainsKey($"Page:{window.Url}")) _scenarioContext.Remove($"Page:{window.Url}");
            _scenarioContext.Add($"Page:{window.Url}", window);
            _scenarioContext["NumberOfOpenedWindows"] = windowCount;
            windowCount++;
        }
    }

    public string ReturnWindowUrlBasedOnIndex(string index)
    {
        var url = string.Empty;
        switch(index)
        {
            case "first opened instance":
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window1.html";
                break;
            case "second instance of first browser":
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window1.html#";
                break;
            case "second opened instance":
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window2.html";
                break;
            case "second instance of second browser":
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window2.html#";
                break;
            case "third opened instance":
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window3.html";
                break;
            case "second instance of third browser":
                url = "https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window3.html#";
                break;
            case "baseUrl":
                url = "https://www.way2automation.com/way2auto_jquery/frames-and-windows.php#load_box";
                break;
            default:
                throw new NotImplementedException($"Index: {index} was not found in switch case options while trying to get window url!");
        }
        return url;
    }

    public async Task CloseDesiredWindow(string desiredWindow)
    {
        await CommonFunctions.WaitForAllPagesToBeReadyAsync(_page);
        var pageUrl = ReturnWindowUrlBasedOnIndex(desiredWindow);
        var pageUrl2 = ReturnWindowUrlBasedOnIndex(desiredWindow) + "#";
        var allPages = new List<IPage>(_page.Context.Pages);
        foreach(var window in allPages)
        {
            if (window.Url.Equals(pageUrl)) await window.CloseAsync();
            if (window.Url.Equals(pageUrl2)) await window.CloseAsync();
        }
    }

    public async Task<IPage> GetPageForWindow(string desiredWindow)
    {
        await CommonFunctions.WaitForAllPagesToBeReadyAsync(_page);
        var pageUrl = ReturnWindowUrlBasedOnIndex(desiredWindow);
        var allPages = new List<IPage>(_page.Context.Pages);
        foreach (var window in allPages)
        {
            if (window.Url.Equals(pageUrl)) return window;
        }
        return null;
    }

    public async Task CloseAllWindowsExcept(string openWindow)
    {
        await CommonFunctions.WaitForAllPagesToBeReadyAsync(_page);
        var windowCount = 0;
        var pageUrl = ReturnWindowUrlBasedOnIndex(openWindow);
        var baseUrl = ReturnWindowUrlBasedOnIndex("baseUrl");
        var allPages = new List<IPage>(_page.Context.Pages);
        foreach (var window in allPages)
        {
            await Task.Delay(100);
            var windowUrl = window.Url;
            if (!windowUrl.Equals(pageUrl) && !windowUrl.Equals(baseUrl)) await window.CloseAsync();
            windowCount++;
        }
    }

    public async Task CloseAllWindows()
    {
        await CommonFunctions.WaitForAllPagesToBeReadyAsync(_page);
        var pageUrl = ReturnWindowUrlBasedOnIndex("baseUrl");
        var allPages = new List<IPage>(_page.Context.Pages);
        foreach (var window in allPages)
        {
            if (!window.Url.Equals(pageUrl)) await window.CloseAsync();
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