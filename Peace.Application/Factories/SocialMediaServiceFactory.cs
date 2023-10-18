using Microsoft.Extensions.DependencyInjection;
using Peace.Application.Interfaces;
using Peace.Application.Services;

namespace Peace.Application.Factories
{
    public class SocialMediaServiceFactory : ISocialMediaServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SocialMediaServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISocialMediaService CreateService(string serviceName)
        {
            // Use a switch statement or other logic to create the appropriate service based on the service name
            switch (serviceName.ToLowerInvariant())
            {
                case "facebook":
                    return _serviceProvider.GetRequiredService<FacebookService>();
                case "instagram":
                    return _serviceProvider.GetRequiredService<InstagramService>();
                case "twitter":
                    return _serviceProvider.GetRequiredService<TwitterService>();
                case "google":
                    return _serviceProvider.GetRequiredService<GoogleService>();
                case "linkedin":
                    return _serviceProvider.GetRequiredService<LinkedinService>();
                default:
                    throw new NotImplementedException();
            }
        }
    }

}

