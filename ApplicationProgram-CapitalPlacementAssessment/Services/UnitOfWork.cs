﻿using ApplicationProgram_CapitalPlacementAssessment.Common.Helpers;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ApplicationProgram_CapitalPlacementAssessment.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _config;
        public UnitOfWork()
        {
            ProgramService = new ProgramService();
            ApplicationStageService = new ApplicationStageService();
            ApplicationFormService = new ApplicationFormService();
        }
        public IApplicationFormService ApplicationFormService { get; private set; }
        public IApplicationStageService ApplicationStageService { get; private set; }
        public IProgramService ProgramService { get; private set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Capital placement - Application program assessment");
            BaseCall();
        }


        // Home
        void PrintOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Application Program");
            Console.WriteLine("2. Application Form");
            Console.WriteLine("3. Application Stage");
            Console.WriteLine("4. Application Program Preview");
            Console.WriteLine("5. Exit");
        }
        void BaseCall()
        {
            Console.WriteLine("Welcome aboard");
            int option = 0;
            while (true)
            {
                try
                {
                    PrintOptions();
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid number");
                }
                do
                {
                    switch (option)
                    {
                        case 0:
                            BaseCall();
                            break;
                        case 1:
                            new ApplicationProgramHelper().HandleApplicationProgramOptions();
                            break;
                        case 2:
                            new ApplicationFormHelper().HandleApplicationFormOptions();
                            break;
                        case 3:
                            new ApplicationStageHelper().HandleApplicationStageOptions();
                            break;
                        case 4:
                            new ApplicationProgramHelper().HandleApplicationProgramPreviewOptions();
                            break;
                        case 5:
                            Console.WriteLine("Thank you");
                            Environment.Exit(0);
                            break;
                        default:
                            option = 0;
                            break;
                    }
                } while (option < 5);
                Console.WriteLine("Have a nice day");
                Environment.Exit(0);
            }
        }
    }
}
