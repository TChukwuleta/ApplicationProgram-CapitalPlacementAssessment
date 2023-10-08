namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public class AdditionalQuestion
    {
        public string? ApplicantDescription { get; set; }
        public int YearOfGraduation { get; set; }
        public Question? Question { get; set; }
        public bool RejectedByUkEmbassy { get; set; }
    }

    public class Question
    {
        public QuestionType? QuestionType { get; set; }
        public string? QustionTypeDesc { get; set; }
        public string? QuestionDescription { get; set; }
        public string? Choice { get; set; }
        public int MaximumChoiceAllowed { get; set; }
        public bool EnableOthers { get; set; }
        public bool DisqualifyCandidateForNegativeResponse { get; set; }
    }
}
