using ApplicationProgram_CapitalPlacementAssessment.Context;
using ApplicationProgram_CapitalPlacementAssessment.Core;
using ApplicationProgram_CapitalPlacementAssessment.Core.Models;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationProgram_CapitalPlacementAssessment.Services
{
    public class ApplicationStageService : IApplicationStageService
    {
        private readonly ApplicationDbContext _context;
        public ApplicationStageService()
        {
            _context = new ApplicationDbContext();
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
                    return Result.Success<ApplicationStageService>($"Application stages retrieved successfully", applicationStages);
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
                    return Result.Success<ApplicationStageService>($"Application stage retrieved successfully", applicationStage);
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
                    return Result.Success<ApplicationStageService>($"Application stage retrieved successfully", applicationStage);
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

        public async Task<Result> UpdateApplicationProgramWithApplicationStage(string programId, string name)
        {
            try
            {
                IProgramService programService = new ProgramService();
                var program = await programService.GetById(programId);
                if (!program.Status || program?.Data == null)
                {
                    return program;
                }
                var entity = new ApplicationStage
                {
                    ApplicationProgramId = programId,
                    Name = name,
                    StageType = StageType.VideoInterview,
                    StageTypeDesc = StageType.VideoInterview.ToString(),
                };
                
                await _context.SaveChangesAsync();
                return Result.Success<ApplicationFormService>("Application program updated successfully with application form");
            }
            catch (Exception ex)
            {
                return Result.Exception<ApplicationFormService>($"Update failed. Program Id: {programId}", ex);
            }
        }
    }
}
