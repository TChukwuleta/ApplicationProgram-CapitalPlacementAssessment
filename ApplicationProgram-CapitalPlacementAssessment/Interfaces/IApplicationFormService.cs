using ApplicationProgram_CapitalPlacementAssessment.Core.Models;

namespace ApplicationProgram_CapitalPlacementAssessment.Interfaces
{
    public interface IApplicationFormService
    {
        Task<Result> UpdateApplicationForm(string programId, int formType);
        Task<Result> GetAllApplicationForms();
        Task<Result> GetApplicationFormsByProgramId(string programId);
        Task<Result> GetById(string id);
    }
}
