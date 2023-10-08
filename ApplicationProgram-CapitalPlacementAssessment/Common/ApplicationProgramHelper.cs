using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using ApplicationProgram_CapitalPlacementAssessment.Services;

namespace ApplicationProgram_CapitalPlacementAssessment.Common
{
    internal class ApplicationProgramHelper
    {
        public ApplicationProgramHelper()
        {
        }

        public void HandleApplicationProgramOptions()
        {
            int option = 0;
            string title = string.Empty;
            string id = string.Empty;
            string description = string.Empty;
            IUnitOfWork unitOfWork = new UnitOfWork();
            while (true)
            {
                try
                {
                    ApplicationProgramOptions();
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid employee name");
                }
                do
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Please enter a title");
                            title = Console.ReadLine();
                            Console.WriteLine("Please enter a description");
                            description = Console.ReadLine();
                            CreateApplicationProgram(title, description, unitOfWork);
                            break;
                        case 2:
                            Console.WriteLine("Please enter a valid id");
                            id = Console.ReadLine();
                            Console.WriteLine("Please enter the new title");
                            title = Console.ReadLine();
                            Console.WriteLine("Please enter the new description");
                            description = Console.ReadLine();
                            UpdateApplicationProgram(id, title, description, unitOfWork);
                            break;
                        case 3:
                            Console.WriteLine("Please enter a valid id");
                            id = Console.ReadLine();
                            GetApplicationProgramById(id, unitOfWork);
                            break;
                        case 4:
                            Console.WriteLine("Please enter a valid title");
                            title = Console.ReadLine();
                            GetApplicationProgramByTitle(title, unitOfWork);
                            break;
                        default:
                            option = 0;
                            break;
                    }
                } while (option != 5);
                Console.WriteLine("Have a nice day");
            }
        }

        // Application Program
        void ApplicationProgramOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Create application program");
            Console.WriteLine("2. Update application program");
            Console.WriteLine("3. Get application program by id");
            Console.WriteLine("4. Get application program by name");
            Console.WriteLine("5. Exit");
        }

        // Application program
        void CreateApplicationProgram(string title, string description, IUnitOfWork unitOfWork)
        {
            unitOfWork.ProgramService.CreateProgram(title, description).GetAwaiter();
        }
        void UpdateApplicationProgram(string id, string title, string description, IUnitOfWork unitOfWork)
        {
            unitOfWork.ProgramService.UpdateProgram(id, title, description).GetAwaiter();
        }
        void GetApplicationProgramById(string id, IUnitOfWork unitOfWork)
        {
            unitOfWork.ProgramService.GetById(id).GetAwaiter();
        }
        void GetApplicationProgramByTitle(string title, IUnitOfWork unitOfWork)
        {
            unitOfWork.ProgramService.GetByTitle(title).GetAwaiter();
        }
    }
}
