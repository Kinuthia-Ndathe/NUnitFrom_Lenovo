using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightDemo01;

public class NUnitPlaywright : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://www.eaapp.somee.com");
    }

    [Test]
    public async Task Test1()
    {                
        
        //using Locators instead of await Page.ClickAsync("text=Login");
        var lnkLogin = Page.Locator("text=Login");
        await lnkLogin.ClickAsync();
        
        //await Page.ClickAsync("text=Login");        
        await Page.FillAsync(selector:"#UserName", value:"admin");
        await Page.FillAsync(selector:"#Password", value:"password");
        
        //await Page.ClickAsync(selector:"text=Log in");
        //Using Locators with Page Locator Options
        var btnLogin = Page.Locator(selector:"input", new PageLocatorOptions{ HasTextString = ("Log In")});
        await btnLogin.ClickAsync();

        await Expect(Page.Locator(selector:"text='Employee Details'")).ToBeVisibleAsync();

    }

}