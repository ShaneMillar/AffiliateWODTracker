using System.Windows.Input;

namespace AffiliateWODTracker.Mobile
{
    public partial class MainPage : ContentPage
    {
        public ICommand RegisterCommand { get; }

        public MainPage()
        {
            InitializeComponent();
            RegisterCommand = new Command(OnRegisterClicked);
            BindingContext = this;
        }
        private async void OnRegisterClicked()
        {
            // Navigate to the Register Page
            await Shell.Current.GoToAsync("RegisterPage");
        }
    }
}
