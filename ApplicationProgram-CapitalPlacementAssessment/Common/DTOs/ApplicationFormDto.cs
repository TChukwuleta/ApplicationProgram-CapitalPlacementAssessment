using ApplicationProgram_CapitalPlacementAssessment.Common.Mappings;
using ApplicationProgram_CapitalPlacementAssessment.Core;

namespace ApplicationProgram_CapitalPlacementAssessment.Common.DTOs
{
    public class ApplicationFormDto : IMapFrom<ApplicationForm>
    {
        public required string ApplicationProgramId { get; set; }
        public string? CoverImage { get; set; }
        public PersonalInformation? PersonalInformation { get; set; }
        public Profile? Profile { get; set; }
        public AdditionalQuestion? AdditionalQuestion { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<ApplicationForm, ApplicationFormDto>();
            profile.CreateMap<ApplicationFormDto, ApplicationForm>();

            profile.CreateMap<PersonalInformation, PersonalInformationDto>();
            profile.CreateMap<PersonalInformationDto, PersonalInformation>();

            profile.CreateMap<AdditionalQuestion, AdditionalQuestionDto>();
            profile.CreateMap<AdditionalQuestionDto, AdditionalQuestion>();
        }
    }
}
