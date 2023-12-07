using System.Windows.Input;

namespace AffiliateWODTracker.Mobile
{
    public partial class MainPage : ContentPage
    {
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public MainPage()
        {
            InitializeComponent();
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            BindingContext = this;
        }

        private async void OnLoginClicked()
        {
            // Navigate to the Login Page
            await Shell.Current.GoToAsync("LoginPage");
        }

        private async void OnRegisterClicked()
        {
            // Navigate to the Register Page
            await Shell.Current.GoToAsync("RegisterPage");
        }
    }
}
