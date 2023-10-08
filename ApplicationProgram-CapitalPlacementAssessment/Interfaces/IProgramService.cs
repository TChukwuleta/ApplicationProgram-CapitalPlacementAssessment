namespace ApplicationProgram_CapitalPlacementAssessment.Interfaces
{
    public interface IProgramService
    {
        Task CreateProgram(string title, string description);
        Task UpdateProgram(string id, string title, string description);
        Task GetAllProgram();
        Task GetById(string id);
        Task GetByTitle(string title);
    }
}
