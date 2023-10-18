using Microsoft.AspNetCore.Mvc;
using Peace.API.Models;
using Peace.Application.Models;

namespace Peace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly SocialMediaHandler _socialMediaHandler;

        public SocialMediaController(SocialMediaHandler socialMediaHandler)
        {
            _socialMediaHandler = socialMediaHandler;
        }

        // POST-metod för att ta emot data
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAsync([FromBody] SocialMediaRequest request)
        {
            try
            {
                var dto = new SocialMediaRequestDto {
                    DateOfDeath = request.DateOfDeath,
                    Email = request.Email,
                    FullName = request.FullName,
                    SelectedPlatforms = request.SelectedPlatforms
                };
                await _socialMediaHandler.HandleSocialMediaRequest(dto);
                return Ok("Begäran mottagen och behandlad.");
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate response
                return StatusCode(500, "Något gick fel.");
            }
        }
    }
}
