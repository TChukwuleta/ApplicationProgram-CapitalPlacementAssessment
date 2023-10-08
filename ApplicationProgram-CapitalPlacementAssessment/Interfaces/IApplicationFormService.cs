using ApplicationProgram_CapitalPlacementAssessment.Core.Models;

namespace ApplicationProgram_CapitalPlacementAssessment.Interfaces
{
    public interface IApplicationFormService
    {
        Task<Result> UpdateApplicationForm(string programId, int formType, string? image = null,
            string? position = null, string? companyName = null, string? firstName = null, string? lastName = null,
            int? questionType = 0, int? yearOfGraduation = 0, string? personalDescription = null, bool rejectedByUkEmbassy = false,
            string? choice = null);
        Task<Result> GetAllApplicationForms();
        Task<Result> GetApplicationFormsByProgramId(string programId);
        Task<Result> GetById(string id);
    }
}
