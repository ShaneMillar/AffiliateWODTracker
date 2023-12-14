using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Core.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AffiliateWODTracker.Mobile.Views.Workouts;

public partial class AddWorkout : ContentPage
{
    private Member member = new Member();

    public AddWorkout()
    {
        InitializeComponent();
        GetCurrentMember();
    }

    private async Task GetCurrentMember()
    {
        var httpClient = await GetHttpClientAsync();
        var response = await httpClient.GetAsync($"{MobileConfig.HttpConfig.API}/Member/GetCurrentMember");
        if (!response.IsSuccessStatusCode)
        {
            await DisplayAlert("Error", "Unable to retrieve current member. Please try again later.", "OK");
            return;
        }

        var content = await response.Content.ReadAsStringAsync();
        member = JsonConvert.DeserializeObject<Member>(content);
    }

    private async void OnPostWorkoutClicked(object sender, EventArgs e)
    {
        if (!ValidateInputs())
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        var workout = CreateWorkout();
        var httpClient = await GetHttpClientAsync();
        var json = JsonConvert.SerializeObject(workout);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Assuming /Workout/PostWorkout is your API endpoint for posting workouts
        var response = await httpClient.PostAsync($"{MobileConfig.HttpConfig.API}/Workout/PostWorkout", content);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Workout posted successfully.", "OK");
            // Navigate back to home or another page as necessary
        }
        else
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            await DisplayAlert("Error", $"Failed to post workout: {errorResponse}", "OK");
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
            AffiliateId = member.AffiliateId,
            UserId = member.UserId
        };
    }

    private async Task<HttpClient> GetHttpClientAsync()
    {
        var client = new HttpClient();
        var token = await SecureStorage.GetAsync("jwt_token");
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        return client;
    }
}
