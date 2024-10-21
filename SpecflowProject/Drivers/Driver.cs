using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace SpecFlowProject1.Drivers
{
    public class Driver : IAsyncDisposable
    {
        private IBrowser? _browser;
        private IPage? _page; 
        private bool _isDisposed = false; 

        
        private Driver(IBrowser browser, IPage page)
        {
            _browser = browser;
            _page = page;
        }

        
        public static async Task<Driver> CreateAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = new List<string> { "--start-maximized" }
            });
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport,

            });

            var page = await context.NewPageAsync();
            //page.SetDefaultTimeout(20000);
            return new Driver(browser, page);
        }

        public IPage Page => _page ?? throw new InvalidOperationException("Page is not initialized.");

        public async ValueTask DisposeAsync() 
        {
            if (!_isDisposed)
            {
                await _browser?.CloseAsync(); 
                _isDisposed = true;
            }
        }

        public async Task TakeScreenshotAsync(string filePath)
        {
            if (_page != null)
            {
                await _page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = Path.Combine(Directory.GetCurrentDirectory(), filePath),
                    FullPage = true 
                });
            }
            else
            {
                throw new InvalidOperationException("Page is not initialized. Cannot take a screenshot.");
            }
        }

    }
}
