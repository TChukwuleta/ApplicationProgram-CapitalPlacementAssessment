namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public class WorkExperience : PrimaryEntity
    {
        public string? Company { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
