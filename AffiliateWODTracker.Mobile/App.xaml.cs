using AffiliateWODTracker.Mobile.Views.Account;

namespace AffiliateWODTracker.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));

        }
    }
}
