using ApplicationProgram_CapitalPlacementAssessment.Common.Mappings;
using ApplicationProgram_CapitalPlacementAssessment.Core;

namespace ApplicationProgram_CapitalPlacementAssessment.Common.DTOs
{
    public class ApplicationStageDto : IMapFrom<ApplicationStage>
    {
        public required string Name { get; set; }
        public bool DisplayStageToCandidate { get; set; }
        public StageType StageType { get; set; }
        public string? StageTypeDesc { get; set; }
        public VideoInterviewStage? VideoInterviewStage { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<ApplicationStage, ApplicationStageDto>();
            profile.CreateMap<ApplicationStageDto, ApplicationStage>();

            profile.CreateMap<VideoInterviewStage, VideoInterviewStageDto>();
            profile.CreateMap<VideoInterviewStageDto, VideoInterviewStage>();
        }
    }
}
