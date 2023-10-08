namespace ApplicationProgram_CapitalPlacementAssessment.Interfaces
{
    public interface IProfileService
    {
        Task CreateProgram(string resume);
        Task UpdateProgram(string resume);
        Task GetAllProgram();
        Task GetById(string id);
    }
}
