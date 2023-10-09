using ApplicationProgram_CapitalPlacementAssessment.Common.DTOs;
using ApplicationProgram_CapitalPlacementAssessment.Context;
using ApplicationProgram_CapitalPlacementAssessment.Core;
using ApplicationProgram_CapitalPlacementAssessment.Core.Models;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApplicationProgram_CapitalPlacementAssessment.Services
{
    public class ApplicationStageService : IApplicationStageService
    {
        private readonly ApplicationDbContext _context;
        private static IMapper _mapper;
        public ApplicationStageService()
        {
            _context = new ApplicationDbContext();
            InitializeAutomapper();
        }
        public async Task<Result> GetAllProgramStages()
        {
            try
            {
                if (_context.ApplicationStages != null)
                {
                    var applicationStages = await _context.ApplicationStages.Include(c => c.VideoInterviewStage).ToListAsync();
                    if (applicationStages == null || !applicationStages.Any())
                    {
                        return Result.Failure<ApplicationStageService>($"No record found");
                    }
                    var mappedResponse = _mapper.Map<List<ApplicationStageDto>>(applicationStages);
                    return Result.Success<ApplicationStageService>($"Application stages retrieved successfully", mappedResponse);
                }
                else
                {
                    return Result.Failure<ApplicationStageService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ApplicationStageService>(ex);
            }
        }

        public async Task<Result> GetApplicationStagesByProgramId(string programId)
        {
            try
            {
                if (_context.ApplicationPrograms != null && _context.ApplicationStages != null)
                {
                    var applicationStage = await _context.ApplicationStages.Include(c => c.VideoInterviewStage)
                        .FirstOrDefaultAsync(c => c.ApplicationProgramId == programId);
                    if (applicationStage == null || string.IsNullOrEmpty(applicationStage?.Id))
                    {
                        return Result.Failure<ApplicationStageService>($"No record found");
                    }
                    var mappedResponse = _mapper.Map<ApplicationStageDto>(applicationStage);
                    return Result.Success<ApplicationStageService>($"Application stage retrieved successfully", mappedResponse);
                }
                else
                {
                    return Result.Failure<ApplicationStageService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ApplicationStageService>(ex);
            }
        }

        public async Task<Result> GetById(string id)
        {
            try
            {
                if (_context.ApplicationStages != null)
                {
                    var applicationStage = await _context.ApplicationStages.Include(c => c.VideoInterviewStage).FirstOrDefaultAsync(c => c.Id == id);
                    if (applicationStage == null || string.IsNullOrEmpty(applicationStage?.Id))
                    {
                        return Result.Failure<ApplicationStageService>($"No record found");
                    }
                    var mappedResponse = _mapper.Map<ApplicationStageDto>(applicationStage);
                    return Result.Success<ApplicationStageService>($"Application stage retrieved successfully", mappedResponse);
                }
                else
                {
                    return Result.Failure<ApplicationStageService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ApplicationStageService>($"Id: {id}", ex);
            }
        }

        public async Task<Result> UpdateApplicationProgramWithApplicationStage(string programId, string name, int stageType)
        {
            try
            {
                VideoInterviewStage videoInterviewStage = new VideoInterviewStage();
                IProgramService programService = new ProgramService();
                var program = await programService.GetById(programId);
                if (!program.Status || program?.Data == null)
                {
                    return program;
                }
                StageType? stageTypeEnum = (StageType)stageType;
                if (stageTypeEnum == null)
                {
                    return Result.Failure<ApplicationStageService>($"Invalid stage type");
                }
                if (stageTypeEnum == StageType.VideoInterview)
                {
                    videoInterviewStage.DurationType = DurationType.Seconds;
                    videoInterviewStage.DurationTypeDesc = DurationType.Seconds.ToString();
                    videoInterviewStage.MaximumVideoDuration = 10;
                    videoInterviewStage.AdditionalInformation = "Balablue";
                    videoInterviewStage.Question = ":How are you?";
                    videoInterviewStage.VideoSubmissionDeadline = 0;
                }
                var entity = await _context.ApplicationStages.FirstOrDefaultAsync(c => c.ApplicationProgramId == programId);
                if (entity != null) 
                {
                    entity.ApplicationProgramId = programId;
                    entity.Name = name;
                    entity.DisplayStageToCandidate = true;
                    entity.StageType = StageType.VideoInterview;
                    entity.StageTypeDesc = StageType.VideoInterview.ToString();
                    entity.VideoInterviewStage = videoInterviewStage;
                }
                else
                {
                    entity = new ApplicationStage
                    {
                        ApplicationProgramId = programId,
                        Name = name,
                        DisplayStageToCandidate = true,
                        StageType = StageType.VideoInterview,
                        StageTypeDesc = StageType.VideoInterview.ToString(),
                        VideoInterviewStage = videoInterviewStage
                    };
                    await _context.ApplicationStages.AddAsync(entity);
                }
                await _context.SaveChangesAsync();
                return Result.Success<ApplicationStageService>("Application program updated successfully with application form");
            }
            catch (Exception ex)
            {
                return Result.Exception<ApplicationStageService>($"Update failed. Program Id: {programId}", ex);
            }
        }

        private static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationStage, ApplicationStageDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }
    }
}
