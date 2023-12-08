using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Core.Models;
using Newtonsoft.Json;

namespace AffiliateWODTracker.Mobile.Views.Account;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        LoadAffiliatesAsync();
    }

    private async Task LoadAffiliatesAsync()
    {
        try
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(MobileConfig.HttpConfig.API + "/Affiliate/GetAffiliates");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var affiliates = JsonConvert.DeserializeObject<List<Affiliate>>(content);
                // Update UI accordingly, for example:
                if (affiliates != null && affiliates.Any())
                {
                    affiliatePicker.ItemsSource = affiliates.Select(a => a.Name).ToList();
                }
            }
            else
            {
                // Handle error
            }
        }
        catch (Exception ex)
        {
            var message = ex.Message;
        }
    }


    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (passwordEntry.Text != confirmPasswordEntry.Text)
        {
            // Passwords do not match
            await DisplayAlert("Error", "Passwords do not match", "OK");
            return;
        }

       
        // Collect user input
        var firstName = firstNameEntry.Text;
        var lastName = lastNameEntry.Text;
        var email = emailEntry.Text;
        var phoneNumber = phoneEntry.Text;
        var address = addressEntry.Text;
        var dateOfBirth = dobPicker.Date;
        var affiliate = affiliatePicker.SelectedItem as Affiliate; // Assuming you have an Affiliate class
        var password = passwordEntry.Text;

        // Perform input validation

        // Send data to your backend for registration
        // This will involve calling an API endpoint and handling the response
        // You would typically use HttpClient to perform the API call
        // On successful registration, navigate to the login page or main app page
    }
}
