using AffiliateWODTracker.Core.Models;

namespace AffiliateWODTracker.Mobile.Views.Account;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        // Initialize affiliatePicker with available affiliates
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
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
