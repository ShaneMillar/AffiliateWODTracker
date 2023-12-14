using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Windows.Input;

namespace AffiliateWODTracker.Mobile.Views.Account;

public partial class LoginPage : ContentPage
{
    public ICommand RegisterCommand { get; }
    private readonly HttpClient _httpClient = new HttpClient();
    public LoginPage()
	{
		InitializeComponent();
        RegisterCommand = new Command(OnRegisterClicked);
        BindingContext = this;
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (!ValidateInputs())
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        Preferences.Set("RememberMe", rememberMeCheckBox.IsChecked);

        var userLogin = CreateUserLogin();
        var token = await LoginUserAsync(userLogin);

        if (!string.IsNullOrEmpty(token))
        {
            await SecureStorage.SetAsync("jwt_token", token);
            Preferences.Set("IsLoggedIn", true);
            await Shell.Current.GoToAsync("//HomePage");
        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid login attempt.", "OK");
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

    private async Task<string> LoginUserAsync(LoginModel userLogin)
    {
        var json = JsonConvert.SerializeObject(userLogin);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var apiUrl = $"{MobileConfig.HttpConfig.API}{APIEndpoints.AccountController.Login}";
        var response = await _httpClient.PostAsync(apiUrl, content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var token = JObject.Parse(responseContent)["token"].ToString();
            return token;
        }
        else
        {
            return null;
        }
    }


    private async void OnRegisterClicked()
    {
        // Navigate to the Register Page
        await Shell.Current.GoToAsync("RegisterPage");
    }

   
}