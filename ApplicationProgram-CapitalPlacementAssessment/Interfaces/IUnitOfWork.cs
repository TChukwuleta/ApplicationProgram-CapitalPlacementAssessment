namespace ApplicationProgram_CapitalPlacementAssessment.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IApplicationFormService ApplicationFormService { get; }
        public IApplicationStageService ApplicationStageService { get; }
        public IProgramService ProgramService { get; }
        void Run();
    }
}
