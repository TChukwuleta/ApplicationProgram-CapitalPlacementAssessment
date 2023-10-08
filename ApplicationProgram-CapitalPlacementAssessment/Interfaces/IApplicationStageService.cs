namespace ApplicationProgram_CapitalPlacementAssessment.Interfaces
{
    public interface IApplicationStageService
    {
        Task CreateProgram(string name);
        Task UpdateProgram(string name);
        Task GetAllProgram();
        Task GetById(string id);
    }
}
