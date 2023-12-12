using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Core.Models;
using Newtonsoft.Json;
using System.Text;

namespace AffiliateWODTracker.Mobile.Views.Account;

public partial class RegisterPage : ContentPage
{
    private readonly HttpClient _httpClient = new HttpClient();

    public RegisterPage()
    {
        InitializeComponent();
        LoadAffiliatesAsync();
    }

    private async Task LoadAffiliatesAsync()
    {
        var response = await _httpClient.GetAsync($"{MobileConfig.HttpConfig.API}/Affiliate/GetAffiliates");
        if (!response.IsSuccessStatusCode)
        {
            await DisplayAlert("Error", "Unable to load affiliates. Please try again later.", "OK");
            return;
        }

        var content = await response.Content.ReadAsStringAsync();
        var affiliates = JsonConvert.DeserializeObject<List<Affiliate>>(content);
        affiliatePicker.ItemsSource = affiliates ?? new List<Affiliate>();
        affiliatePicker.ItemDisplayBinding = new Binding("Name");
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (!ValidateInputs())
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        if (passwordEntry.Text != confirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        var userRegistration = CreateUserRegistration();
        var response = await RegisterUserAsync(userRegistration);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Account created successfully.", "OK");
            await Shell.Current.GoToAsync("LoginPage");
        }
        else
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            await DisplayAlert("Registration Failed", errorResponse, "OK");
        }
    }

    private bool ValidateInputs()
    {
        return !string.IsNullOrWhiteSpace(firstNameEntry.Text) &&
               !string.IsNullOrWhiteSpace(lastNameEntry.Text) &&
               !string.IsNullOrWhiteSpace(emailEntry.Text) &&
               !string.IsNullOrWhiteSpace(phoneEntry.Text) &&
               !string.IsNullOrWhiteSpace(addressEntry.Text) &&
               affiliatePicker.SelectedItem != null &&
               !string.IsNullOrWhiteSpace(passwordEntry.Text) &&
               !string.IsNullOrWhiteSpace(confirmPasswordEntry.Text);
    }

    private RegisterModel CreateUserRegistration()
    {
        var selectedAffiliate = (Affiliate)affiliatePicker.SelectedItem;
        return new RegisterModel
        {
            FirstName = firstNameEntry.Text,
            LastName = lastNameEntry.Text,
            Email = emailEntry.Text,
            PhoneNumber = phoneEntry.Text,
            Address = addressEntry.Text,
            DateOfBirth = dobPicker.Date,
            AffiliateId = selectedAffiliate.AffiliateId,
            Password = passwordEntry.Text
        };
    }

    private async Task<HttpResponseMessage> RegisterUserAsync(RegisterModel userRegistration)
    {
        var json = JsonConvert.SerializeObject(userRegistration);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var apiUrl = $"{MobileConfig.HttpConfig.API}/Account/Register";
        return await _httpClient.PostAsync(apiUrl, content);
    }
}
