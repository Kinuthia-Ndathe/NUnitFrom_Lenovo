/*
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightDemo01;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();

        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions 
        {
            Headless = false
        });

        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");
        await page.ClickAsync("text=Login");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "EAPP.jpg"
        });

        //UI Interaction:
        await page.FillAsync(selector:"#Username", value:"admin");
        await page.FillAsync(selector:"#Password", value:"password");
        await page.ClickAsync(selector:"text=Log in");
        var isExist = await page.Locator(selector:"text='Employee Details'").IsVisibleAsync(); //the Locator method locates a certain item on the page and returns true if the value defined matches what is specified on this line.
        Assert.IsTrue(isExist);
    }
}
*/