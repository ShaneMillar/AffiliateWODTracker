using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Core.Models;
using Newtonsoft.Json;

namespace AffiliateWODTracker.Mobile.Service
{
    public class MemberService
    {
        private readonly HttpClientService _httpClientService;

        public MemberService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<Member> GetCurrentMemberAsync()
        {
            try
            {
                var httpClient = await _httpClientService.GetClientAsync();
                var response = await httpClient.GetAsync($"{MobileConfig.HttpConfig.API}{APIEndpoints.MembersController.GetCurrentMemberApiEndpoint}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Member>(content);
                }
                else
                {
                    // Consider throwing an exception or handling it as you see fit
                    throw new InvalidOperationException("Unable to retrieve current member.");
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception and then rethrowing
                // Alternatively, handle it based on your app's error handling policy
                throw new InvalidOperationException("An unexpected error occurred while retrieving current member.", ex);
            }
        }
    }
}
