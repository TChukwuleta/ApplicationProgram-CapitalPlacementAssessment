namespace ApplicationProgram_CapitalPlacementAssessment.Interfaces
{
    public interface IApplicationFormService
    {
        Task CreateProgram(string image);
        Task UpdateProgram(string image);
        Task GetAllProgram();
        Task GetById(string id);
    }
}
