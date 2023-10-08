using ApplicationProgram_CapitalPlacementAssessment.Core.Models;

namespace ApplicationProgram_CapitalPlacementAssessment.Interfaces
{
    public interface IProgramService
    {
        Task<Result> CreateProgram(string title, string description);
        Task<Result> UpdateProgram(string id, string title, string description);
        Task<Result> GetAllProgram();
        Task<Result> GetById(string id);
        Task<Result> GetByTitle(string title);
        Task<Result> GetAllProgramDetails();
        Task<Result> GetProgramDetailsById(string id);
    }
}
