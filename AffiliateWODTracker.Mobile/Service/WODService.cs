using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Core.ViewModels;
using Newtonsoft.Json;

namespace AffiliateWODTracker.Mobile.Service
{
    public class WODService
    {
        private readonly HttpClientService _httpClientService;

        public WODService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<List<AffiliateWODViewModel>> LoadWorkoutsAsync(int affiliateId)
        {
            var httpClient = await _httpClientService.GetClientAsync();
            var url = $"{MobileConfig.HttpConfig.API}{APIEndpoints.WODsController.GetWODSByAffiliateIdApiEndpoint}?affiliateId={affiliateId}";

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AffiliateWODViewModel>>(content);
            }
            else
            {
                // Depending on your error handling policy, you may want to throw an exception,
                // return an empty list, or handle it differently
                throw new HttpRequestException("Unable to load workouts.");
            }
        }
    }
}
