namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public class ApplicationForm : PrimaryEntity
    {
        public required string ApplicationProgramId { get; set; }
        public string? CoverImage { get; set; }
        public PersonalInformation? PersonalInformation { get; set; }
        public Profile? Profile { get; set; }
        public AdditionalQuestion? AdditionalQuestion { get; set; }
    }
}
