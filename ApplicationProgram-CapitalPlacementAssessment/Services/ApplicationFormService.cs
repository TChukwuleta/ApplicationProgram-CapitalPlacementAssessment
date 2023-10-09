using ApplicationProgram_CapitalPlacementAssessment.Common.DTOs;
using ApplicationProgram_CapitalPlacementAssessment.Context;
using ApplicationProgram_CapitalPlacementAssessment.Core;
using ApplicationProgram_CapitalPlacementAssessment.Core.Models;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApplicationProgram_CapitalPlacementAssessment.Services
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly ApplicationDbContext _context;
        private static IMapper _mapper;
        public ApplicationFormService()
        {
            _context = new ApplicationDbContext();
        }
        public async Task<Result> UpdateApplicationForm(string programId, int formType)
        {
            try
            {
                IProgramService programService = new ProgramService();
                var program = await programService.GetById(programId);
                if (!program.Status || program?.Data == null)
                {
                    return program;
                }
                var entity = await _context.ApplicationForms.FirstOrDefaultAsync(c => c.ApplicationProgramId == programId);
                if (entity != null)
                {
                    switch (formType)
                    {
                        case 1:
                            entity.PersonalInformation = GetPersonalInformationRequest("Tee", "Boss");
                            break;
                        case 2:
                            entity.Profile = GetProfileRequest(entity.Id, "Software developer", "Capital placement");
                            break;
                        case 3:
                            entity.AdditionalQuestion = GetAdditionalQuestionRequest(3, "nil", 2023, "capital placement", false);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    entity = new ApplicationForm
                    {
                        ApplicationProgramId = programId,
                        CoverImage = "www.google.com"
                    };
                    switch (formType)
                    {
                        case 1:
                            entity.PersonalInformation = GetPersonalInformationRequest("Tee", "Boss");
                            break;
                        case 2:
                            entity.Profile = GetProfileRequest(entity.Id, "Software developer", "Capital placement");
                            break;
                        case 3:
                            entity.AdditionalQuestion = GetAdditionalQuestionRequest(3, "nil", 2023, "capital placement", false);
                            break;
                        default:
                            break;
                    }
                    await _context.ApplicationForms.AddAsync(entity);
                }
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
                    var forms = await _context.ApplicationForms.ToListAsync();
                    if (forms == null || !forms.Any())
                    {
                        return Result.Failure<ApplicationFormService>($"No record found");
                    }
                    var mappedResponse = _mapper.Map<List<ApplicationFormDto>>(forms);
                    return Result.Success<ApplicationFormService>($"Application forms retrieved successfully", mappedResponse);
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
                    var form = await _context.ApplicationForms.Include(c => c.PersonalInformation)
                        .Include(c => c.Profile).Include(c => c.AdditionalQuestion).FirstOrDefaultAsync(c => c.ApplicationProgramId == programId);
                    if (form == null || string.IsNullOrEmpty(form?.Id))
                    {
                        return Result.Failure<ApplicationFormService>($"No record found");
                    }
                    var mappedResponse = _mapper.Map<ApplicationFormDto>(form);
                    return Result.Success<ApplicationFormService>($"Application forms retrieved successfully", mappedResponse);
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
                    var form = await _context.ApplicationForms.Include(c => c.PersonalInformation).Include(c => c.AdditionalQuestion).Include(c => c.Profile).FirstOrDefaultAsync(c => c.Id == id);
                    if (form == null || string.IsNullOrEmpty(form?.Id))
                    {
                        return Result.Failure<ApplicationFormService>($"No record found");
                    }
                    var mappedResponse = _mapper.Map<ApplicationFormDto>(form);
                    return Result.Success<ApplicationFormService>($"Application form retrieved successfully", mappedResponse);
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
        private Core.Profile GetProfileRequest(string applicationFormId, string position, string companyName)
        {
            List<WorkExperience> workplaces = new List<WorkExperience>();
            workplaces.Add(new WorkExperience
            {
                Company = companyName,
                Title = position,
                StartDate = DateTime.Now.AddYears(-3).Date,
                EndDate = DateTime.Today.Date
            });
            var entity = new Core.Profile
            {
                ApplicationFormId = applicationFormId,
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
        private static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationForm, ApplicationFormDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }
    }
}
