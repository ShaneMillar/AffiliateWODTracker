using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Core.ViewModels;
using AffiliateWODTracker.Mobile.Service;
using AffiliateWODTracker.Mobile.Services;

namespace AffiliateWODTracker.Mobile.Views.Home;

public partial class HomePage : ContentPage
{
    private readonly MemberService _memberService;
    private readonly WODService _wodService;

    private Member _member;
    public List<AffiliateWODViewModel> Workouts { get; private set; } // Property for data binding

    public HomePage(MemberService memberService, WODService wodService)
    {
        InitializeComponent();
        _memberService = memberService;
        _wodService = wodService;
        this.BindingContext = this; // Set the BindingContext for data binding
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!AppStateService.Instance.IsFirstLoad)
        {
            // Refresh the member information
            _member = await _memberService.GetCurrentMemberAsync();

            // Refresh the workouts list
            await LoadAffiliateWorkoutsAsync();
        }
    }

    private async Task LoadAffiliateWorkoutsAsync()
    {
        // Clear the existing workouts
        Workouts?.Clear();

        // Load the new workouts
        var affiliateWorkouts = await _wodService.LoadWorkoutsAsync(_member.AffiliateId);

        // Update the UI, if necessary
        WorkoutsCollectionView.ItemsSource = affiliateWorkouts;
    }
}
