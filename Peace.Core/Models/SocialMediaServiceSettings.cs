using Microsoft.Extensions.Configuration;

namespace Peace.Core.Models
{
    public class SocialMediaServiceSettings
    {
        public readonly string BaseAddress;
        public readonly string RequestUri;
        public readonly string AccessToken;

        public SocialMediaServiceSettings(IConfiguration configuration, string serviceName)
        {
            var serviceSettings = configuration.GetSection($"{serviceName}ServiceSettings");
            BaseAddress = serviceSettings["BaseAddress"] ?? throw new MissingFieldException();
            RequestUri = serviceSettings["RequestUri"] ?? throw new MissingFieldException();
            AccessToken = serviceSettings["AccessToken"] ?? throw new MissingFieldException();
        }
    }
}

