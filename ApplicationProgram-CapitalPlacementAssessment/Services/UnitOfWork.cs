using ApplicationProgram_CapitalPlacementAssessment.Interfaces;

namespace ApplicationProgram_CapitalPlacementAssessment.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            
        }
        public IApplicationFormService ApplicationFormService { get; private set; }

        public IApplicationStageService ApplicationStageService { get; private set; }

        public IProfileService ProfileService { get; private set; }

        public IProgramService ProgramService { get; private set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Capital placement - Application program assessment");
        }
    }
}
