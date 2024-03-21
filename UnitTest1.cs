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
        Assert.That(isExist, Is.True);
    }

    [Test]
    public async Task TestWithPOM()
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
        
        LoginPage loginPage = new LoginPage(page);
        await loginPage.ClickLogin();
        await loginPage.Login(userName:"admin", password:"password");
        var isExist = await loginPage.IsEmployeeDetailsExist();
        Assert.That(isExist.Is.True);

    }



    [Test]
    public async Task WaitTest()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        await page.GotoAsync(url:"https://demos.telerik.com/kendo-ui/window/angular");
        await page.Locator( selector:"text=Calendar May 2022SuMoTuWeThFrSa1234567891011121314151617181920212223242526272829 >> [aria-label=\"Close\"]").ClickAsync();
        await page.Locator( selector:"text=Calendar May 2022SuMoTuWeThFrSa1234567891011121314151617181920212223242526272829 >> [aria-label=\"Close\"]").ClickAsync();
        //Click button:has-text("Open AJAX context")
        await page.Locator( selector:"button:has-text(\"Open AJAX content\")").ClickAsync();

    }
}

