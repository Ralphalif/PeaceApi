namespace Peace.API.Models
{
    public class SocialMediaRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DateOfDeath { get; set; }
        public string Relation { get; set; }
        public List<Platform> SelectedPlatforms { get; set; }
        public List<string> DeathRelatedDocuments { get; set; }
        public string Comments { get; set; }

    }
}

