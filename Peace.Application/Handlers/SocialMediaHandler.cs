using Microsoft.Extensions.DependencyInjection;
using Peace.Application.Interfaces;
using Peace.Application.Models;

public class SocialMediaHandler
{
    private readonly IServiceProvider _serviceProvider;

    public SocialMediaHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task HandleSocialMediaRequest(SocialMediaRequestDto request)
    {
        // Implement handling logic for social media requests
        try
        {
            var selectedServices = GetSelectedServices(request);

            foreach (var service in selectedServices)
            {
                await service.HandleRequest(request);
            }

            // Handle other aspects of the request, such as documentation, comments, etc.

            // Optionally, you can perform post-processing or logging here.
        }
        catch (Exception ex)
        {
            // Handle exceptions, log errors, or take appropriate actions
            throw;
        }
    }

    private IEnumerable<ISocialMediaService> GetSelectedServices(SocialMediaRequestDto request)
    {
        var selectedServiceNames = request.SelectedPlatforms;

        // Create instances of selected services using the service provider
        var services = new List<ISocialMediaService>();
        foreach (var serviceName in selectedServiceNames)
        {
            var service = _serviceProvider.GetRequiredService<ISocialMediaServiceFactory>()
                .CreateService(serviceName);

            if (service != null)
            {
                services.Add(service);
            }
        }

        return services;
    }
}
