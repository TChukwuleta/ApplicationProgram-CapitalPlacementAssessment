﻿using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using ApplicationProgram_CapitalPlacementAssessment.Services;
using Newtonsoft.Json;

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
                        case 5:
                            GetAllApplicationProgram(unitOfWork);
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
                            GetApplicationProgramDetailsById(id, unitOfWork);
                            break;
                        case 2:
                            GetAllApplicationProgramDetails(unitOfWork);
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
            Console.WriteLine("4. Get all application programs");
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
        void CreateApplicationProgram(string title, string description, IUnitOfWork unitOfWork)
        {
            var createProgram = unitOfWork.ProgramService.CreateProgram(title, description).GetAwaiter();
            var result = createProgram.GetResult();
            Console.WriteLine(result.Message);
        }
        void UpdateApplicationProgram(string id, string title, string description, IUnitOfWork unitOfWork)
        {
            var updateProgam = unitOfWork.ProgramService.UpdateProgram(id, title, description).GetAwaiter();
            var result = updateProgam.GetResult();
            Console.WriteLine(result.Message);
        }
        void GetApplicationProgramById(string id, IUnitOfWork unitOfWork)
        {
            var program = unitOfWork.ProgramService.GetById(id).GetAwaiter();
            var result = program.GetResult();
            if (!result.Status)
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(JsonConvert.SerializeObject(result.Data));
        }
        void GetApplicationProgramDetailsById(string id, IUnitOfWork unitOfWork)
        {
            var program = unitOfWork.ProgramService.GetProgramDetailsById(id).GetAwaiter();
            var result = program.GetResult();
            if (!result.Status)
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(JsonConvert.SerializeObject(result.Data));
        }
        void GetApplicationProgramByTitle(string title, IUnitOfWork unitOfWork)
        {
            var program = unitOfWork.ProgramService.GetByTitle(title).GetAwaiter();
            var result = program.GetResult();
            if (!result.Status)
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(JsonConvert.SerializeObject(result.Data));
        }
        void GetAllApplicationProgram(IUnitOfWork unitOfWork)
        {
            var programs = unitOfWork.ProgramService.GetAllProgram().GetAwaiter();
            var result = programs.GetResult();
            if (!result.Status)
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(JsonConvert.SerializeObject(result.Data));
        }
        void GetAllApplicationProgramDetails(IUnitOfWork unitOfWork)
        {
            var programs = unitOfWork.ProgramService.GetAllProgramDetails().GetAwaiter();
            var result = programs.GetResult();
            if (!result.Status)
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(JsonConvert.SerializeObject(result.Data));
        }
    }
}
