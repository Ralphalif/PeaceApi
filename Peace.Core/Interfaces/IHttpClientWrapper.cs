using Peace.Core.Models;

namespace Peace.Core.Interfaces
{
	public interface IHttpClientWrapper
	{
        Task<string> GetAsync(SocialMediaServiceSettings socialMediaServiceSettings);
        Task<string> GetAsync(string baseAddress, string requestUri, string accessToken);
    }
}

