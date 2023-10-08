namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public class WorkExperience : PrimaryEntity
    {
        public string? Company { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
