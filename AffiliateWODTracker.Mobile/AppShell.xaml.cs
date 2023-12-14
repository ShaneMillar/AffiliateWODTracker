using AffiliateWODTracker.Core.Common;
using System.Windows.Input;

namespace AffiliateWODTracker.Mobile
{
    public partial class AppShell : Shell
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public ICommand LogoutCommand { get; }
        public AppShell()
        {
            InitializeComponent();

            LogoutCommand = new Command(OnLogoutClicked);
            this.BindingContext = this;
        }

        private async void OnLogoutClicked()
        {
            try
            {
                var response = await LogoutUserAsync();

                if (response.IsSuccessStatusCode)
                {
                    SecureStorage.Remove("jwt_token");
                    Preferences.Set("IsLoggedIn", false);
                    await Shell.Current.GoToAsync("//LoginPage"); // Navigate to a safe page like the login page
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Logout Failed", errorResponse, "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An exception occurred: {ex.Message}", "OK");
            }
        }

        private async Task<HttpResponseMessage> LogoutUserAsync()
        {
            var apiUrl = $"{MobileConfig.HttpConfig.API}/Account/Logout";
            return await _httpClient.PostAsync(apiUrl, null);
        }
    }
}
