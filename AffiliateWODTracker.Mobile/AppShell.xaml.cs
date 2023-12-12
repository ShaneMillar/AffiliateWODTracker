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
            // Navigate to the Login Page
            var apiUrl = $"{MobileConfig.HttpConfig.API}/Account/Logout";
          
            await _httpClient.PostAsync(apiUrl, null);
            await Shell.Current.GoToAsync("//MainPage");
            Preferences.Set("IsLoggedIn", false);
            this.FlyoutIsPresented = false;
        }
    }
}
