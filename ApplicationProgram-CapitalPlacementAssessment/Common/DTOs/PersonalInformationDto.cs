using ApplicationProgram_CapitalPlacementAssessment.Common.Mappings;
using ApplicationProgram_CapitalPlacementAssessment.Core;

namespace ApplicationProgram_CapitalPlacementAssessment.Common.DTOs
{
    public class PersonalInformationDto : IMapFrom<PersonalInformation>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? IdNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? GenderDesc { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<PersonalInformation, PersonalInformationDto>();
            profile.CreateMap<PersonalInformationDto, PersonalInformation>();
        }
    }
}
