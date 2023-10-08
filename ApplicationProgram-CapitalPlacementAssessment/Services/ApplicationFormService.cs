using ApplicationProgram_CapitalPlacementAssessment.Context;
using ApplicationProgram_CapitalPlacementAssessment.Core;
using ApplicationProgram_CapitalPlacementAssessment.Core.Models;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationProgram_CapitalPlacementAssessment.Services
{
    internal class ApplicationFormService : IApplicationFormService
    {
        private readonly ApplicationDbContext _context;
        public ApplicationFormService()
        {
            _context = new ApplicationDbContext();
        }
        public async Task<Result> UpdateApplicationForm(string programId, int formType, string? image = null, 
            string? position = null, string? companyName = null, string? firstName = null, string? lastName = null,
            int? questionType = 0, int? yearOfGraduation = 0, string? personalDescription= null, bool rejectedByUkEmbassy = false, 
            string? choice = null)
        {
            try
            {
                IProgramService programService = new ProgramService();
                var program = await programService.GetById(programId);
                if (!program.Status || program?.Data == null)
                {
                    return program;
                }
                var entity = new ApplicationForm
                {
                    ApplicationProgramId = programId,
                    CoverImage = image
                };
                switch (formType)
                {
                    case 1:
                        entity.PersonalInformation = GetPersonalInformationRequest(firstName, lastName);
                        break;
                    case 2:
                        entity.Profile = GetProfileRequest(position, companyName);
                        break;
                    case 3:
                        entity.AdditionalQuestion = GetAdditionalQuestionRequest(questionType.Value, personalDescription, yearOfGraduation.Value, choice, rejectedByUkEmbassy);
                        break;
                    default:
                        break;
                }
                await _context.ApplicationForms.AddAsync(entity);
                await _context.SaveChangesAsync();
                return Result.Success<ApplicationFormService>("Application program updated successfully with application form");
            }
            catch (Exception ex)
            {
                return Result.Exception<ApplicationFormService>($"Update failed. Program Id: {programId}", ex);
            }
        }
        

        public async Task<Result> GetAllApplicationForms()
        {
            try
            {
                if (_context.ApplicationForms != null)
                {
                    var forms = await _context.ApplicationForms.Include(c => c.PersonalInformation).Include(c => c.AdditionalQuestion).Include(c => c.Profile).ToListAsync();
                    if (forms == null || !forms.Any())
                    {
                        return Result.Failure<ApplicationFormService>($"No record found");
                    }
                    return Result.Success<ApplicationFormService>($"Application forms retrieved successfully", forms);
                }
                else
                {
                    return Result.Failure<ApplicationFormService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ApplicationFormService>(ex);
            }
        }

        public async Task<Result> GetApplicationFormsByProgramId(string programId)
        {
            try
            {
                if (_context.ApplicationPrograms != null && _context.ApplicationForms != null)
                {
                    var form = await _context.ApplicationPrograms.Include(c => c.ApplicationForm).ThenInclude(c => c.PersonalInformation)
                        .Include(c => c.ApplicationForm).ThenInclude(c => c.AdditionalQuestion)
                        .Include(c => c.ApplicationForm).ThenInclude(c => c.Profile)
                        .FirstOrDefaultAsync(c => c.Id == programId);
                    if (form == null || string.IsNullOrEmpty(form?.Id))
                    {
                        return Result.Failure<ApplicationFormService>($"No record found");
                    }
                    return Result.Success<ApplicationFormService>($"Application forms retrieved successfully", form.ApplicationForm);
                }
                else
                {
                    return Result.Failure<ApplicationFormService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ApplicationFormService>(ex);
            }
        }

        public async Task<Result> GetById(string id)
        {
            try
            {
                if (_context.ApplicationForms != null)
                {
                    var program = await _context.ApplicationForms.Include(c => c.PersonalInformation).Include(c => c.AdditionalQuestion).Include(c => c.Profile).FirstOrDefaultAsync(c => c.Id == id);
                    if (program == null || string.IsNullOrEmpty(program?.Id))
                    {
                        return Result.Failure<ApplicationFormService>($"No record found");
                    }
                    return Result.Success<ApplicationFormService>($"Application form retrieved successfully", program);
                }
                else
                {
                    return Result.Failure<ApplicationFormService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ApplicationFormService>($"Id: {id}", ex);
            }
        }

        private PersonalInformation GetPersonalInformationRequest(string firstname, string lastname)
        {
            var entity = new PersonalInformation
            {
                FirstName = firstname,
                LastName = lastname,
                Email = "test@yopmail.com",
                Phone = "44-919-227",
                Nationality = "Wakanda",
                ResidentialAddress = "Igbokwe",
                IdNumber = Guid.NewGuid().ToString(),
                DateOfBirth = DateTime.Now,
                Gender = Gender.Male,
                GenderDesc = Gender.Male.ToString()
            };
            return entity;
        }
        private Profile GetProfileRequest(string position, string companyName)
        {
            List<WorkExperience> workplaces = new List<WorkExperience>();
            workplaces.Add(new WorkExperience
            {
                Company = companyName,
                Title = position,
                StartDate = DateTime.Now.AddYears(-3).Date,
                EndDate = DateTime.Today.Date
            });
            var entity = new Profile
            {
                WorkExperiences = workplaces,
                Resume = "www.google.com",
                Educations = new List<Education>()
            };
            return entity;
        }
        private AdditionalQuestion GetAdditionalQuestionRequest(int questionType, string personalDescription, int yearOfGraduation, string choice, bool rejectedByUkEmbassy)
        {
            Question question = new Question { 
                EnableOthers = true,
                DisqualifyCandidateForNegativeResponse = true,
                MaximumChoiceAllowed = 1
            };
            var entity = new AdditionalQuestion
            {
                ApplicantDescription = personalDescription,
                YearOfGraduation = yearOfGraduation,
                RejectedByUkEmbassy = rejectedByUkEmbassy
            };
            QuestionType questionEnum = (QuestionType)questionType;
            switch (questionEnum)
            {
                case QuestionType.Paragraph:
                    break;
                case QuestionType.ShortAnswer:
                    break;
                case QuestionType.YesOrNo:
                    break;
                case QuestionType.DropDown:
                    break;
                case QuestionType.MultipleChoice:
                    break;
                case QuestionType.Date:
                    break;
                case QuestionType.Number:
                    break;
                case QuestionType.FileUpload:
                    break;
                case QuestionType.VideoQuestion:
                    break;
                default:
                    throw new Exception("Invalid question type");
            }
            question.QuestionType = questionEnum;
            question.Choice = choice;
            question.QustionTypeDesc = questionEnum.ToString();
            return entity;
        }
    }
}
