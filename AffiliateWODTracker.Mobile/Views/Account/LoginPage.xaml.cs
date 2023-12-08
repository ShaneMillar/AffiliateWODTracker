namespace AffiliateWODTracker.Mobile.Views.Account;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
	{
        // Collect user input
        var email = emailEntry.Text;
        var lastName = passwordEntry.Text;

        // Send data to your backend for registration
    }
}