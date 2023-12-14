using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Mobile.Service;
using Newtonsoft.Json;
using System.Text;

namespace AffiliateWODTracker.Mobile.Views.Workouts;

public partial class AddWorkout : ContentPage
{
    private readonly HttpClientService _httpClientService; 
    private Member _member;

 
    public AddWorkout(HttpClientService httpClientService)
    {
        InitializeComponent();
        _httpClientService = httpClientService; 
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await InitializeMemberAsync();
    }

    private async Task InitializeMemberAsync()
    {
        try
        {
            var httpClient = await _httpClientService.GetClientAsync();
            var response = await httpClient.GetAsync($"{MobileConfig.HttpConfig.API}{APIEndpoints.MembersController.GetCurrentMemberApiEndpoint}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _member = JsonConvert.DeserializeObject<Member>(content);
            }
            else
            {
                await DisplayAlert("Error", "Unable to retrieve current member. Please try again later.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and provide feedback to the user.
            await DisplayAlert("Error", $"An unexpected error occurred: {ex.Message}", "OK");
        }
    }

    private async void OnPostWorkoutClicked(object sender, EventArgs e)
    {
        if (!ValidateInputs())
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        var workout = CreateWorkout();
        await PostWorkoutAsync(workout);
    }

    private async Task PostWorkoutAsync(WODModel workout)
    {
        try
        {
            var httpClient = await _httpClientService.GetClientAsync();
            var json = JsonConvert.SerializeObject(workout);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{MobileConfig.HttpConfig.API}{APIEndpoints.WODsController.PostWorkoutApiEndpoint}", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Workout posted successfully.", "OK");
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", $"Failed to post workout: {errorResponse}", "OK");
            }
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and provide feedback to the user.
            await DisplayAlert("Error", $"An unexpected error occurred: {ex.Message}", "OK");
        }
    }

    private bool ValidateInputs()
    {
        return
            !string.IsNullOrWhiteSpace(titleEntry.Text) &&
            !string.IsNullOrWhiteSpace(descriptionEditor.Text);
    }

    private WODModel CreateWorkout()
    {
        return new WODModel
        {
            Title = titleEntry.Text,
            Description = descriptionEditor.Text,
            CreatedDate = DateTime.Now,
            AffiliateId = _member.AffiliateId,
            UserId = _member.UserId
        };
    }
}
