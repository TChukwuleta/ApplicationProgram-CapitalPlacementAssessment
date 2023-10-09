using ApplicationProgram_CapitalPlacementAssessment.Core.Models;

namespace ApplicationProgram_CapitalPlacementAssessment.Interfaces
{
    public interface IApplicationStageService
    {
        Task<Result> UpdateApplicationProgramWithApplicationStage(string programId, string name, int stageType);
        Task<Result> GetAllProgramStages();
        Task<Result> GetApplicationStagesByProgramId(string programId);
        Task<Result> GetById(string id);
    }
}
