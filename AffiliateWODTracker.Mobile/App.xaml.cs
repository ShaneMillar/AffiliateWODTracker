using AffiliateWODTracker.Mobile.Views.Account;
using AffiliateWODTracker.Mobile.Views.Home;

namespace AffiliateWODTracker.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            if (Preferences.Get("IsLoggedIn", false))
            {
                // Navigate to HomePage
                Shell.Current.GoToAsync("//HomePage");
            }
            else
            {
                Shell.Current.GoToAsync("//MainPage");
            }

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            //account
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            //Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            //Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            // ... etc ...


            //home
            // Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));

        }
    }
}
