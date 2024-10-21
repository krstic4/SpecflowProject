using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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

    }
}
