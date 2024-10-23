using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowProject.Pages
{
    public class CommonFunctions
    {
        private ScenarioContext _scenarioContext;
        private IPage _page;

        public CommonFunctions(IPage page, ScenarioContext scenarioContext)
        {
            _page = page;
            _scenarioContext = scenarioContext;
        }

        public void StringVerification(string expected, string actual)
        {
            Assert.That(expected.Equals(actual), $"Strings are not equal! Expected is: '{expected}' and actual is: '{actual}'");
        }

        public void VerifyUrl(string expectedUrl, string actualUrl)
        {
            Assert.That(expectedUrl.Equals(actualUrl), $"Url's are not equal! Expected is: '{expectedUrl}' and actual is: '{actualUrl}'");
        }

        public async Task WaitForAllPagesToBeReadyAsync(IPage page, int timeout = 10000)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.ElapsedMilliseconds < timeout)
            {
                var pages = page.Context.Pages.ToList();
                bool allReady = true;

                foreach (var p in pages)
                {
                    var readyState = await p.EvaluateAsync<string>("document.readyState");
                    if (readyState != "complete")
                    {
                        allReady = false;
                        break; 
                    }
                }

                if (allReady)
                {
                    return; 
                }

                await Task.Delay(100); 
            }

            throw new TimeoutException($"Not all pages reached ready state within {timeout}ms.");
        }
    }
}
