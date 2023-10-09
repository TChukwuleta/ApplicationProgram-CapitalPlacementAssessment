using ApplicationProgram_CapitalPlacementAssessment.Common.Mappings;
using ApplicationProgram_CapitalPlacementAssessment.Core;

namespace ApplicationProgram_CapitalPlacementAssessment.Common.DTOs
{
    public class QuestionDto : IMapFrom<Question>
    {
        public QuestionType? QuestionType { get; set; }
        public string? QustionTypeDesc { get; set; }
        public string? QuestionDescription { get; set; }
        public string? Choice { get; set; }
        public int MaximumChoiceAllowed { get; set; }
        public bool EnableOthers { get; set; }
        public bool DisqualifyCandidateForNegativeResponse { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Question, QuestionDto>();
            profile.CreateMap<QuestionDto, Question>();
        }
    }
}
