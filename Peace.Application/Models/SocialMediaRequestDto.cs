namespace Peace.Application.Models
{
    public class SocialMediaRequestDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DateOfDeath { get; set; }
        public List<string> SelectedPlatforms { get; set; }
    }
}

