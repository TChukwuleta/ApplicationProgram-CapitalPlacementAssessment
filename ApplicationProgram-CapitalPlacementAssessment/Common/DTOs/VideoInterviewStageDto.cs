using ApplicationProgram_CapitalPlacementAssessment.Common.Mappings;
using ApplicationProgram_CapitalPlacementAssessment.Core;

namespace ApplicationProgram_CapitalPlacementAssessment.Common.DTOs
{
    public class VideoInterviewStageDto : IMapFrom<VideoInterviewStage>
    {
        public string? Question { get; set; }
        public string? AdditionalInformation { get; set; }
        public int MaximumVideoDuration { get; set; }
        public DurationType? DurationType { get; set; }
        public string? DurationTypeDesc { get; set; }
        public int VideoSubmissionDeadline { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<VideoInterviewStage, VideoInterviewStageDto>();
            profile.CreateMap<VideoInterviewStageDto, VideoInterviewStage>();
        }
    }
}
