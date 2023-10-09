using ApplicationProgram_CapitalPlacementAssessment.Core.Models;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using ApplicationProgram_CapitalPlacementAssessment.Services;
using Newtonsoft.Json;

namespace ApplicationProgram_CapitalPlacementAssessment.Common.Helpers
{
    public class ApplicationProgramHelper
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
                    Console.WriteLine("Please enter a valid option");
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
                            var createProgramResult = CreateApplicationProgram(title, description, unitOfWork);
                            Console.WriteLine(createProgramResult.Message);
                            break;
                        case 2:
                            Console.WriteLine("Please enter a valid id");
                            id = Console.ReadLine();
                            Console.WriteLine("Please enter the new title");
                            title = Console.ReadLine();
                            Console.WriteLine("Please enter the new description");
                            description = Console.ReadLine();
                            var updateProgramResult = UpdateApplicationProgram(id, title, description, unitOfWork);
                            Console.WriteLine(updateProgramResult.Message);
                            break;
                        case 3:
                            Console.WriteLine("Please enter a valid id");
                            id = Console.ReadLine();
                            var programByIdResponse = GetApplicationProgramById(id, unitOfWork);
                            if (!programByIdResponse.Status)
                            {
                                Console.WriteLine(programByIdResponse.Message);
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(programByIdResponse.Data));
                            break;
                        case 4:
                            Console.WriteLine("Please enter a valid title");
                            title = Console.ReadLine();
                            var programByTitleResponse = GetApplicationProgramByTitle(title, unitOfWork);
                            if (!programByTitleResponse.Status)
                            {
                                Console.WriteLine(programByTitleResponse.Message);
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(programByTitleResponse.Data));
                            break;
                        case 5:
                            var allApplicationPrograms = GetAllApplicationProgram(unitOfWork);
                            if (!allApplicationPrograms.Status)
                            {
                                Console.WriteLine(allApplicationPrograms.Message);
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(allApplicationPrograms.Data));
                            break;
                        default:
                            option = 0;
                            break;
                    }
                } while (option != 6);
                Console.WriteLine("Have a nice day");
            }
        }

        public void HandleApplicationProgramPreviewOptions()
        {
            int option = 0;
            string id = string.Empty;
            IUnitOfWork unitOfWork = new UnitOfWork();
            while (true)
            {
                try
                {
                    ApplicationProgramPreviewOptions();
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid option");
                }
                do
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Please enter a valid id");
                            id = Console.ReadLine();
                            var singleProgramResult = GetApplicationProgramDetailsById(id, unitOfWork);
                            if (!singleProgramResult.Status)
                            {
                                Console.WriteLine(singleProgramResult.Message);
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(singleProgramResult.Data));
                            break;
                        case 2:
                            var allProgramResult = GetAllApplicationProgramDetails(unitOfWork);
                            if (!allProgramResult.Status)
                            {
                                Console.WriteLine(allProgramResult.Message);
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(allProgramResult.Data));
                            break;
                        default:
                            option = 0;
                            break;
                    }
                } while (option != 6);
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
            Console.WriteLine("5. Get all application programs");
            Console.WriteLine("6. Exit");
        }

        // Application Program preview
        void ApplicationProgramPreviewOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Get application program details by id");
            Console.WriteLine("2. Get all application program details");
            Console.WriteLine("3. Exit");
        }

        // Application program
        public Result CreateApplicationProgram(string title, string description, IUnitOfWork unitOfWork)
        {
            var createProgram = unitOfWork.ProgramService.CreateProgram(title, description).GetAwaiter();
            var result = createProgram.GetResult();
            return result;
        }
        public Result UpdateApplicationProgram(string id, string title, string description, IUnitOfWork unitOfWork)
        {
            var updateProgam = unitOfWork.ProgramService.UpdateProgram(id, title, description).GetAwaiter();
            var result = updateProgam.GetResult();
            return result;
        }
        public Result GetApplicationProgramById(string id, IUnitOfWork unitOfWork)
        {
            var program = unitOfWork.ProgramService.GetById(id).GetAwaiter();
            var result = program.GetResult();
            return result;
        }
        public Result GetApplicationProgramDetailsById(string id, IUnitOfWork unitOfWork)
        {
            var program = unitOfWork.ProgramService.GetProgramDetailsById(id).GetAwaiter();
            var result = program.GetResult();
            return result;
        }
        public Result GetApplicationProgramByTitle(string title, IUnitOfWork unitOfWork)
        {
            var program = unitOfWork.ProgramService.GetByTitle(title).GetAwaiter();
            var result = program.GetResult();
            return result;
        }
        public Result GetAllApplicationProgram(IUnitOfWork unitOfWork)
        {
            var programs = unitOfWork.ProgramService.GetAllProgram().GetAwaiter();
            var result = programs.GetResult();
            return result;
        }
        public Result GetAllApplicationProgramDetails(IUnitOfWork unitOfWork)
        {
            var programs = unitOfWork.ProgramService.GetAllProgramDetails().GetAwaiter();
            var result = programs.GetResult();
            return result;
        }
    }
}
