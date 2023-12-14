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

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            //account
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }

        protected override async void OnStart()
        {
            base.OnStart();

            if (Preferences.Get("IsLoggedIn", false))
            {
                await Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                await Shell.Current.GoToAsync("//HomePage");
            }
        }
    }
}
