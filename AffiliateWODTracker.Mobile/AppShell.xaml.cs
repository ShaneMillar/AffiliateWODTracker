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
            var response = await LogoutUserAsync();

            if (response.IsSuccessStatusCode)
            {
                await Shell.Current.GoToAsync("//MainPage");
                Preferences.Set("IsLoggedIn", false);
                this.FlyoutIsPresented = false;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Logout Failed", errorResponse, "OK");
            }
        }

        private async Task<HttpResponseMessage> LogoutUserAsync()
        {
            var apiUrl = $"{MobileConfig.HttpConfig.API}/Account/Logout";
            return await _httpClient.PostAsync(apiUrl, null);
        }
    }
}
