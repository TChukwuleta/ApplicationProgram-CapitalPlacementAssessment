

using AutoMapper;

namespace ApplicationProgram_CapitalPlacementAssessment.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
