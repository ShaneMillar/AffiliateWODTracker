using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Core.Models;
using Newtonsoft.Json;
using System.Text;

namespace AffiliateWODTracker.Mobile.Views.Account;

public partial class LoginPage : ContentPage
{
    private readonly HttpClient _httpClient = new HttpClient();
    public LoginPage()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
	{
        if (!ValidateInputs())
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        // Save the state of the Remember Me checkbox
        Preferences.Set("RememberMe", rememberMeCheckBox.IsChecked);

        var userLogin = CreateUserLogin();
        var response = await LoginUserAsync(userLogin);

        if (response.IsSuccessStatusCode)
        {
            Preferences.Set("IsLoggedIn", true);
            await Shell.Current.GoToAsync("//HomePage");
        }
        else
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            await DisplayAlert("Login Failed", errorResponse, "OK");
        }

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Restore the state of the Remember Me checkbox
        rememberMeCheckBox.IsChecked = Preferences.Get("RememberMe", false);
    }

    private bool ValidateInputs()
    {
        return
               !string.IsNullOrWhiteSpace(emailEntry.Text) &&
               !string.IsNullOrWhiteSpace(passwordEntry.Text);
              
    }

    private LoginModel CreateUserLogin()
    {
        
        return new LoginModel
        {
            Email = emailEntry.Text,
            Password = passwordEntry.Text,
            RememberMe = rememberMeCheckBox.IsChecked
        };
    }

    private async Task<HttpResponseMessage> LoginUserAsync(LoginModel userLogin)
    {
        var json = JsonConvert.SerializeObject(userLogin);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var apiUrl = $"{MobileConfig.HttpConfig.API}/Account/Login";
        return await _httpClient.PostAsync(apiUrl, content);
    }
}