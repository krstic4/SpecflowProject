using Microsoft.Playwright;
using NUnit.Framework;
using SpecflowProject.Pages;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Pages;

public class HomePage
{
    private IPage _page;
    private ScenarioContext _scenarioContext;
    private IPage _newTab;
    public HomePage(IPage page, ScenarioContext scenariocontext)
    {
        _page = page;
        _scenarioContext = scenariocontext;
    }
    private ILocator NavigationBar => _page.Locator("//ul[@class='responsive-tabs']//li//a");
    private IFrameLocator FrameLocator(string srcValue) => _page.FrameLocator($"//iframe[@src='{srcValue}']");
    private ILocator NavBar => _page.Locator("//div[@class='internal_navi']");
    private CommonFunctions CommonFunctions => new CommonFunctions(_page, _scenarioContext);

    public async Task ClickNavigationBar(string text)
    {
        var navBarElements = await NavigationBar.AllAsync();
        foreach (var item in navBarElements)
        {
            var actualItem = await item.InnerTextAsync();
            if (actualItem.ToLower().Equals(text.ToLower()))
            {
                await item.ClickAsync();
                break;
            }
        }
    }

    public IFrameLocator GetFrameLocatorByTabName(string tabName)
    {
        switch (tabName.ToLower())
        {
            case "open new window":
                tabName = "frames-windows/defult1.html";
                break;
            case "new browser tab":
                tabName = "frames-windows/defult1.html";
                break;
            case "open seprate new window":
                tabName = "frames-windows/defult2.html";
                break;
            case "open new seprate window":
                tabName = "frames-windows/defult2.html";
                break;
            case "frame set":
                tabName = "frames-windows/defult3.html";
                break;
            case "open frameset window":
                tabName = "frames-windows/defult3.html";
                break;
            case "open multiple windows":
                tabName = "frames-windows/defult4.html";
                break;
            case "open multiple pages":
                tabName = "frames-windows/defult4.html";
                break;
            default:
                throw new NotImplementedException($"Case:'{tabName}' not found!");

        }
        var frame = FrameLocator(tabName);
        return frame;
    }

    public async Task<string> GetTextFromFrame(string tabName)
    {
        var frameLocator = GetFrameLocatorByTabName(tabName);
        var text = string.Empty;
        try
        {
            text = await frameLocator.Locator("//a").InnerTextAsync();
        }
        catch (PlaywrightException e)
        {
            Console.WriteLine($"Could not take text from locator: '{frameLocator.Locator("//a")}'! Exception message: '{e.Message}'");
            throw;
        }
        text.ToString();
        return text;
    }

    public async Task ClickOnTextInFrame(string tabName)
    {
        var frameLocator = GetFrameLocatorByTabName(tabName);

        try
        {
            await frameLocator.Locator("//a").ClickAsync();
        }
        catch (PlaywrightException e)
        {
            Console.WriteLine($"Could not click on this text in frame: '{tabName}'!! Exception message: '{e.Message}'");
            throw; 
        }
        
    }

    public async Task<IPage> GetFocusOnTab(string url)
    {
        await CommonFunctions.WaitForAllPagesToBeReadyAsync(_page);
        var pages = _page.Context.Pages;
        int index = -1;
       
        for (int i = 0; i < pages.Count; i++)
        {
            if (pages[i].Url.Equals(url))
            {
                index = i;
                break;
            }
        }

        _newTab = _page.Context.Pages[index]; 
        await _newTab.WaitForLoadStateAsync();
        return _newTab;
    }

    public async Task VerifyNavBarIsDisplayed()
    {
        bool isVisible = await NavBar.IsVisibleAsync();
        Assert.That(isVisible, "Home page is not displayed, navigaton bar cannot be found!");
    }
}