using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightDemo01.Pages;

public class LoginPage
{
    private IPage _page;
    private readonly ILocator _lnkLogin;
    private readonly ILocator _txtUserName;
    private readonly ILocator _txtPassword;
    private readonly ILocator _btnLogin;
    private readonly ILocator _lnkEmployeeDetails
    public LoginPage(IPage page) //constructor
    {
        _page = page;
        _lnkLogin = _page.Locator( selector:"text=Login");
        _txtUserName = _page.Locator( selector:"#UserName");
        _txtPassword = _page.Locator( selector:"#Password");
        _btnLogin = _page.Locator( selector:"text=Log in");
        _lnkEmployeeDetails = _page.Locator( selector:"text='Employee Details'");

    }

    public async Task ClickLogin() => await _lnkLogin.CheckAsync();

    public async Task Login(string UserName, string Password)
    {
        await _txtUserName.FillAsync(UserName);
        await _txtPassword.FillAsync(Password);
        await _btnLogin.ClickAsync();
    }

    public async Task<bool> IsEmployeeDetailsExist () => await _lnkEmployeeDetails.IsVisibleAsync();

}