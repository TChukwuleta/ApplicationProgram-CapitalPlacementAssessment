﻿using ApplicationProgram_CapitalPlacementAssessment.Core.Models;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using ApplicationProgram_CapitalPlacementAssessment.Services;
using Newtonsoft.Json;

namespace ApplicationProgram_CapitalPlacementAssessment.Common
{
    public class ApplicationStageHelper
    {
        public ApplicationStageHelper()
        {
            
        }

        void ApplicationStageOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Update application program with application stage");
            Console.WriteLine("2. Get application stage by id");
            Console.WriteLine("3. Get application application stage by application program id");
            Console.WriteLine("4. Get application all application stages");
            Console.WriteLine("5. Exit");
        }

        public void HandleApplicationStageOptions()
        {
            int option = 0;
            string id = string.Empty;
            string name = string.Empty;
            IUnitOfWork unitOfWork = new UnitOfWork();
            while (true)
            {
                try
                {
                    ApplicationStageOptions();
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
                            Console.WriteLine("Please enter a valid application program id");
                            id = Console.ReadLine();
                            Console.WriteLine("Please enter application stage name");
                            name = Console.ReadLine();
                            var updateApplicationPogram = UpdateApplicationProgramWithApplicationStage(id, name, unitOfWork);
                            Console.WriteLine(updateApplicationPogram.Message);
                            break;
                        case 2:
                            Console.WriteLine("Please enter a valid applications stage id");
                            id = Console.ReadLine();
                            var singleApplicationStage = GetApplicationStageById(id, unitOfWork);
                            if (!singleApplicationStage.Status)
                            {
                                Console.WriteLine(singleApplicationStage.Message);
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(singleApplicationStage.Data));
                            break;
                        case 3:
                            Console.WriteLine("Please enter a valid applications program id");
                            id = Console.ReadLine();
                            var singleApplicationStageByProgramId = GetApplicationStageByApplicationProgramId(id, unitOfWork);
                            if (!singleApplicationStageByProgramId.Status)
                            {
                                Console.WriteLine(singleApplicationStageByProgramId.Message);
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(singleApplicationStageByProgramId.Data));
                            break;
                        case 4:
                            var allApplicationStages = GetAllApplicationStages(unitOfWork);
                            if (!allApplicationStages.Status)
                            {
                                Console.WriteLine(allApplicationStages.Message);
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(allApplicationStages.Data));
                            break;
                        default:
                            option = 0;
                            break;
                    }
                } while (option != 6);
                Console.WriteLine("Have a nice day");
            }
        }

        public Result UpdateApplicationProgramWithApplicationStage(string id, string name, IUnitOfWork unitOfWork)
        {
            var updateProgam = unitOfWork.ApplicationStageService.UpdateApplicationProgramWithApplicationStage(id, name).GetAwaiter();
            var result = updateProgam.GetResult();
            return result;
        }
        public Result GetApplicationStageById(string id, IUnitOfWork unitOfWork)
        {
            var program = unitOfWork.ApplicationStageService.GetById(id).GetAwaiter();
            var result = program.GetResult();
            return result;
        }
        public Result GetApplicationStageByApplicationProgramId(string id, IUnitOfWork unitOfWork)
        {
            var program = unitOfWork.ApplicationStageService.GetApplicationStagesByProgramId(id).GetAwaiter();
            var result = program.GetResult();
            return result;
        }
        public Result GetAllApplicationStages(IUnitOfWork unitOfWork)
        {
            var programs = unitOfWork.ApplicationStageService.GetAllProgramStages().GetAwaiter();
            var result = programs.GetResult();
            return result;
        }
    }
}
