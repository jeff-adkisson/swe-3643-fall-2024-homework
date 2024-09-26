using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class GeneratedTest : PageTest
{
    [Test]
    public async Task MyTest()
    {
        await Page.GotoAsync("https://demo.playwright.dev/todomvc/#/");
        await Page.GetByPlaceholder("What needs to be done?").ClickAsync();
        await Page.GetByPlaceholder("What needs to be done?").FillAsync("Complete homework 3");
        await Page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");
        await Page.GetByLabel("Toggle Todo").CheckAsync();
    }
}