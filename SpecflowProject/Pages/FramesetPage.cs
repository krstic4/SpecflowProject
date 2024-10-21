using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Pages;

public class FramesetPage
{
    private IPage _page;
    private ScenarioContext _scenarioContext;
    public FramesetPage(IPage page, ScenarioContext scenariocontext)
    {
        _page = page;
        _scenarioContext = scenariocontext;
    }

    private IFrameLocator Frames(string frameNumber) => _page.FrameLocator($"//frameset//farme[@name='{frameNumber}']");


    public string GetFrameName(string frameNumber)
    {
        switch (frameNumber.ToLower())
        {
            case "first":
                frameNumber = "topFrame";
                break;
            case "second":
                frameNumber = "contentFrame";
                break;
            default:
                throw new NotImplementedException($"Case:'{frameNumber}' not found!");
        }
        return frameNumber;
    }

    public string GetExpectedFrameContent(string frameNumber)
    {
        switch (frameNumber.ToLower())
        {
            case "first":
                frameNumber = "Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text.";
                break;
            case "second":
                frameNumber = "Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text. Demo text.";
                break;
            default:
                throw new NotImplementedException($"Case:'{frameNumber}' not found!");
        }
        return frameNumber;
    }
    public async Task<string> GetFrameTitleAsync(string frameName)
    {
        var frame = GetFrameByName(frameName);
        var frameTitle = await frame.Result.Locator("//h2").InnerTextAsync();
        return frameTitle.ToString();
    }

    public async Task<string> GetFrameContentAsync(string frameName)
    {
        var frame = GetFrameByName(frameName);
        var frameContent = await frame.Result.Locator("//p").InnerTextAsync();
        return frameContent.ToString();
    }

    public async Task<IFrame> GetFrameByName(string frame1)
    {
        await _page.WaitForLoadStateAsync();
        var frames = _page.Frames;
        frame1 = GetFrameName(frame1);
        var frame = frames.FirstOrDefault(x => x.Name.Equals(frame1));
        if (frame == null) throw new ArgumentException($"Frame: '{frame}' not found!");
        else return frame;
    }

    public async Task VerifyFramesAreDsiplayed(string frame1, string frame2)
    {
        var first = await GetFrameByName(frame1);
        var second = await GetFrameByName(frame2);

        if (first == null || second == null)
        {
            Assert.That(first, Is.Not.Null, "First frame is not visible.");
            Assert.That(second, Is.Not.Null, "Second frame is not visible.");
        }
    }


}