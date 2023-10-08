namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public class Profile
    {
        public required string ApplicationFormId { get; set; }
        public string? Resume { get; set; }
        public List<Education>? Educations { get; set; }
        public required List<WorkExperience> WorkExperiences { get; set; }
    }
}
