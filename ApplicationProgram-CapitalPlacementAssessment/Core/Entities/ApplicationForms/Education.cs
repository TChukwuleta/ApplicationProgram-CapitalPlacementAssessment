namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public class Education : PrimaryEntity
    {
        public required string School { get; set; }
        public Degree Degree { get; set; }
        public required string DegreeDesc { get; set; }
        public string? CourseName { get; set; }
        public string? StudyLocation { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
