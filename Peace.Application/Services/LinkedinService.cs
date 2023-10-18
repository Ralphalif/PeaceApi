using Microsoft.Extensions.Configuration;
using Peace.Application.Interfaces;
using Peace.Application.Models;
using Peace.Core.Interfaces;
using Peace.Core.Models;

namespace Peace.Application.Services
{
	public class LinkedinService : ISocialMediaService
    {
        private readonly SocialMediaServiceSettings _socialMediaServiceSettings;
        private readonly IHttpClientWrapper _httpClientWrapper;

        public LinkedinService(IHttpClientWrapper httpClientWrapper, IConfiguration configuration)
        {
            _httpClientWrapper = httpClientWrapper;
            _socialMediaServiceSettings = (SocialMediaServiceSettings)configuration.GetSection("LinkedinServiceSettings");
        }

        public async Task HandleRequest(SocialMediaRequestDto request)
        {
            // Use the settings for the HTTP request
            string response = await _httpClientWrapper.GetAsync(_socialMediaServiceSettings);

            // Process the response as needed
            // You can deserialize the response content if it's in JSON format, handle errors, etc.
        }
    }
}

