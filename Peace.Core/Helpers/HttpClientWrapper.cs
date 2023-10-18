using Peace.Core.Interfaces;
using Peace.Core.Models;

namespace Peace.Core.Helpers
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(SocialMediaServiceSettings socialMediaServiceSettings)
        {
            return await GetAsync(socialMediaServiceSettings.BaseAddress, socialMediaServiceSettings.RequestUri, socialMediaServiceSettings.AccessToken);
        }

        public async Task<string> GetAsync(string baseAddress, string requestUri, string accessToken)
        {
            try
            {
                // Set the base address for the HTTP client
                _httpClient.BaseAddress = new Uri(baseAddress);

                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Set the access token as a request header
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
                }

                // Make an HTTP GET request to the specified URI
                var response = await _httpClient.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string (you can parse it as needed)
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    // Handle non-successful response (e.g., log, throw an exception, or return an error message)
                    return "Error: Failed to retrieve data from the API.";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log, throw, or return an error message)
                return "Error: " + ex.Message;
            }
        }
    }
}

