using ApplicationProgram_CapitalPlacementAssessment.Core.Models;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using ApplicationProgram_CapitalPlacementAssessment.Services;
using Newtonsoft.Json;

namespace ApplicationProgram_CapitalPlacementAssessment.Common.Helpers
{
    public class ApplicationFormHelper
    {
        public ApplicationFormHelper()
        {

        }

        // Application Program
        void ApplicationFormOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Update application program with form");
            Console.WriteLine("2. Get application form by id");
            Console.WriteLine("3. Get application all application forms by application program id");
            Console.WriteLine("4. Get application all application forms");
            Console.WriteLine("5. Exit");
        }

        public void HandleApplicationFormOptions()
        {
            int option = 0;
            string title = string.Empty;
            int formType = 0;
            string id = string.Empty;
            string programId = string.Empty;
            string description = string.Empty;
            IUnitOfWork unitOfWork = new UnitOfWork();
            while (true)
            {
                try
                {
                    ApplicationFormOptions();
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
                            Console.WriteLine("Please enter application program id");
                            programId = Console.ReadLine();
                            Console.WriteLine("Please enter form type");
                            formType = int.Parse(Console.ReadLine());
                            var updateForm = UpdateApplicationForm(programId, formType, unitOfWork);
                            Console.WriteLine(updateForm.Message);
                            break;
                        case 2:
                            Console.WriteLine("Please enter a valid id");
                            id = Console.ReadLine();
                            var applicationForm = GetApplicationFormById(id, unitOfWork);
                            if (!applicationForm.Status)
                            {
                                Console.WriteLine(applicationForm.Message);
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(applicationForm.Data));
                            break;
                        case 3:
                            Console.WriteLine("Please enter application program id");
                            programId = Console.ReadLine();
                            var applicationProgramForm = GetApplicationFormByProgramId(programId, unitOfWork);
                            if (!applicationProgramForm.Status)
                            {
                                Console.WriteLine(applicationProgramForm.Message);
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(applicationProgramForm.Data));
                            break;
                        case 4:
                            var allApplicationForms = GetAllApplicationForm(unitOfWork);
                            if (!allApplicationForms.Status)
                            {
                                Console.WriteLine(allApplicationForms.Message);
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(allApplicationForms.Data));
                            break;
                        default:
                            option = 0;
                            break;
                    }
                } while (option != 5);
                Console.WriteLine("Have a nice day");
            }
        }

        public Result UpdateApplicationForm(string programId, int formType, IUnitOfWork unitOfWork)
        {
            var updateApplicationForm = unitOfWork.ApplicationFormService.UpdateApplicationForm(programId, formType).GetAwaiter();
            var result = updateApplicationForm.GetResult();
            return result;
        }
        public Result GetApplicationFormById(string id, IUnitOfWork unitOfWork)
        {
            var applicationForm = unitOfWork.ApplicationFormService.GetById(id).GetAwaiter();
            var result = applicationForm.GetResult();
            return result;
        }
        public Result GetApplicationFormByProgramId(string programId, IUnitOfWork unitOfWork)
        {
            var applicationForm = unitOfWork.ApplicationFormService.GetApplicationFormsByProgramId(programId).GetAwaiter();
            var result = applicationForm.GetResult();
            return result;
        }
        public Result GetAllApplicationForm(IUnitOfWork unitOfWork)
        {
            var programs = unitOfWork.ApplicationFormService.GetAllApplicationForms().GetAwaiter();
            var result = programs.GetResult();
            return result;
        }
    }
}
