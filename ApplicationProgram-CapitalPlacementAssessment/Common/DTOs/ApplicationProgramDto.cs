using ApplicationProgram_CapitalPlacementAssessment.Common.Mappings;
using ApplicationProgram_CapitalPlacementAssessment.Core;

namespace ApplicationProgram_CapitalPlacementAssessment.Common.DTOs
{
    public class ApplicationProgramDto : IMapFrom<ApplicationProgram>
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
        public ApplicationStage? ApplicationStage { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<ApplicationProgram, ApplicationProgramDto>();
            profile.CreateMap<ApplicationProgramDto, ApplicationProgram>();

            profile.CreateMap<ApplicationForm, ApplicationFormDto>();
            profile.CreateMap<ApplicationFormDto, ApplicationForm>();


            profile.CreateMap<ApplicationStage, ApplicationStageDto>();
            profile.CreateMap<ApplicationStageDto, ApplicationStage>();
        }
    }
}
