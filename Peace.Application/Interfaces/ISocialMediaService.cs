using System;
using Peace.Application.Models;

namespace Peace.Application.Interfaces
{
    public interface ISocialMediaService
    {
        Task HandleRequest(SocialMediaRequestDto request);
    }
}

