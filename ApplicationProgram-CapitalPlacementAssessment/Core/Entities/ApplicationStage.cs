namespace ApplicationProgram_CapitalPlacementAssessment.Core
{
    public class ApplicationStage : PrimaryEntity
    {
        public required string ApplicationProgramId { get; set; }
        public required string Name { get; set; }
        public bool DisplayStageToCandidate { get; set; }
        public StageType StageType { get; set; }
        public string? StageTypeDesc { get; set; }
        public VideoInterviewStage? VideoInterviewStage { get; set; }
    }

    public class VideoInterviewStage
    {
        public string? Question { get; set; }
        public string? AdditionalInformation { get; set; }
        public int MaximumVideoDuration { get; set; }
        public DurationType? DurationType { get; set; }
        public string? DurationTypeDesc { get; set; }
        public int VideoSubmissionDeadline { get; set; }
    }
}
