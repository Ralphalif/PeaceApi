using System;
namespace Peace.Application.Interfaces
{
    public interface ISocialMediaServiceFactory
    {
        ISocialMediaService CreateService(string serviceName);
    }
}

