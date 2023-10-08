namespace ApplicationProgram_CapitalPlacementAssessment.Interfaces
{
    public interface IProgramService
    {
        Task CreateProgram(string name, string description);
        Task UpdateProgram(string name, string description);
        Task GetAllProgram();
        Task GetById(string id);
    }
}
