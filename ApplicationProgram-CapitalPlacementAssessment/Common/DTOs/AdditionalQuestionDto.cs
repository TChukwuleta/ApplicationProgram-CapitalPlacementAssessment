using ApplicationProgram_CapitalPlacementAssessment.Common.Mappings;
using ApplicationProgram_CapitalPlacementAssessment.Core;

namespace ApplicationProgram_CapitalPlacementAssessment.Common.DTOs
{
    internal class AdditionalQuestionDto : IMapFrom<AdditionalQuestion>
    {
        public string? ApplicantDescription { get; set; }
        public int YearOfGraduation { get; set; }
        public Question? Question { get; set; }
        public bool RejectedByUkEmbassy { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<AdditionalQuestion, AdditionalQuestionDto>();
            profile.CreateMap<AdditionalQuestionDto, AdditionalQuestion>();

            profile.CreateMap<Question, QuestionDto>();
            profile.CreateMap<QuestionDto, Question>();
        }
    }
}
