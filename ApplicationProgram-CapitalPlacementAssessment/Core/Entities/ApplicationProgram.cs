namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public class ApplicationProgram : PrimaryEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string? Summary { get; set; }
        public string? RequiredSkill { get; set; }
        public string? Benefit { get; set; }
        public string? ApplicationCriteria { get; set; }
        public ProgramType ProgramType { get; set; }
        public required string ProgramTypeDesc { get; set; }
        public DateTime? ProgramStartDate { get; set; }
        public DateTime ApplicationOpeningDate { get; set; }
        public DateTime ApplicationClosingDate { get; set; }
        public string? Duration { get; set; }
        public LocationType LocationType { get; set; }
        public required string LocationTypeDesc { get; set; }
        public string? Location { get; set; }
        public int MaximumApplicationNumber { get; set; }
        public ApplicationForm? ApplicationForm { get; set; }
    }
}
