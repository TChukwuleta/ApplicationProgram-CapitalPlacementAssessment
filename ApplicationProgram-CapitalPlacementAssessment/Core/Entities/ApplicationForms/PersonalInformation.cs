namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public class PersonalInformation
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? IdNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? GenderDesc { get; set; }
    }
}
