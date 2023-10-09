using ApplicationProgram_CapitalPlacementAssessment.Common.DTOs;
using ApplicationProgram_CapitalPlacementAssessment.Context;
using ApplicationProgram_CapitalPlacementAssessment.Core;
using ApplicationProgram_CapitalPlacementAssessment.Core.Models;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApplicationProgram_CapitalPlacementAssessment.Services
{
    public class ProgramService : IProgramService
    {
        private readonly ApplicationDbContext _context;
        private static IMapper _mapper;
        public ProgramService()
        {
            InitializeAutomapper();
            _context = new ApplicationDbContext();
        }
        public async Task<Result> CreateProgram(string title, string description)
        {
            try
            {
                var entity = new ApplicationProgram
                {
                    Description = description,
                    Title = title,
                    Summary = "summary",
                    RequiredSkill = "Software development",
                    Benefit = "To get an offer",
                    ApplicationCriteria = "Pass the test",
                    ProgramStartDate = DateTime.Now,
                    ApplicationOpeningDate = DateTime.Now,
                    ApplicationClosingDate = DateTime.Now.AddDays(7),
                    Duration = "7 months",
                    MaximumApplicationNumber = 0,
                    ProgramType = ProgramType.FullTime,
                    ProgramTypeDesc = ProgramType.FullTime.ToString(),
                    LocationType = LocationType.FullyRemote,
                    LocationTypeDesc = LocationType.FullyRemote.ToString(),
                    Location = "Capital placement"
                };
                await _context.ApplicationPrograms.AddAsync(entity);
                await _context.SaveChangesAsync();
                return Result.Success<ProgramService>("Application program created successfully");
            }
            catch (Exception ex)
            {
                return Result.Exception<ProgramService>($"Creation failed. Title: {title} Description: {description}", ex);
            }
        }

        public async Task<Result> UpdateProgram(string id, string title, string description)
        {
            try
            {
                if (_context.ApplicationPrograms != null)
                {
                    var program = await _context.ApplicationPrograms.FirstOrDefaultAsync(c => c.Id == id);
                    if (program == null || string.IsNullOrEmpty(program?.Id))
                    {
                        return Result.Failure<ProgramService>($"No record found");
                    }
                    program.Title = title;
                    program.Description = description;
                    await _context.SaveChangesAsync();
                    return Result.Success<ProgramService>("Application program updated successfully");
                }
                else
                {
                    return Result.Failure<ProgramService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ProgramService>($"Update failed. Id: {id} Title: {title} Description: {description}", ex);
            }
        }

        public async Task<Result> GetAllProgram()
        {
            try
            {
                if (_context.ApplicationPrograms != null)
                {
                    var programs = await _context.ApplicationPrograms.ToListAsync();
                    if (programs == null || !programs.Any())
                    {
                        return Result.Failure<ProgramService>($"No record found");
                    }
                    var mappedResponse = _mapper.Map<List<ApplicationProgramDto>>(programs);
                    return Result.Success<ProgramService>($"Application programs retrieved successfully", mappedResponse);
                }
                else
                {
                    return Result.Failure<ProgramService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ProgramService>(ex);
            }
        }

        public async Task<Result> GetAllProgramDetails()
        {
            try
            {
                IApplicationStageService stageService = new ApplicationStageService();
                IApplicationFormService formService = new ApplicationFormService();
                if (_context.ApplicationPrograms != null)
                {
                    var programs = await _context.ApplicationPrograms.ToListAsync();
                    if (programs == null || !programs.Any())
                    {
                        return Result.Failure<ProgramService>($"No record found");
                    }
                    foreach (var program in programs)
                    {
                        var stage = await stageService.GetApplicationStagesByProgramId(program.Id);
                        if (stage.Status && stage?.Data != null)
                        {
                            var applicationStage = stage.Data as ApplicationStage;
                            program.ApplicationStage = applicationStage;
                        }

                        var form = await formService.GetApplicationFormsByProgramId(program.Id);
                        if (form.Status && form?.Data != null)
                        {
                            var applicationForm = stage.Data as ApplicationForm;
                            program.ApplicationForm = applicationForm;
                        }
                    }
                    var mappedResponse = _mapper.Map<List<ApplicationProgramDto>>(programs);
                    return Result.Success<ProgramService>($"Application programs retrieved successfully", mappedResponse);
                }
                else
                {
                    return Result.Failure<ProgramService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ProgramService>(ex);
            }
        }

        public async Task<Result> GetById(string id)
        {
            try
            {
                if (_context.ApplicationPrograms != null)
                {
                    var program = await _context.ApplicationPrograms.FirstOrDefaultAsync(c => c.Id == id);
                    if (program == null || string.IsNullOrEmpty(program?.Id))
                    {
                        return Result.Failure<ProgramService>($"No record found");
                    }
                    var mappedResponse = _mapper.Map<ApplicationProgramDto>(program);
                    return Result.Success<ProgramService>($"Application programs retrieved successfully", mappedResponse);
                }
                else
                {
                    return Result.Failure<ProgramService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ProgramService>($"Id: {id}", ex);
            }
        }

        public async Task<Result> GetProgramDetailsById(string id)
        {
            try
            {
                IApplicationStageService stageService = new ApplicationStageService();
                IApplicationFormService formService = new ApplicationFormService();
                if (_context.ApplicationPrograms != null && _context.ApplicationStages != null)
                {
                    var program = await _context.ApplicationPrograms.FirstOrDefaultAsync(c => c.Id == id);
                    if (program == null || string.IsNullOrEmpty(program?.Id))
                    {
                        return Result.Failure<ProgramService>($"No record found");
                    }
                    var stage = await stageService.GetApplicationStagesByProgramId(program.Id);
                    if (stage.Status && stage?.Data != null)
                    {
                        var applicationStage = stage.Data as ApplicationStage;
                        program.ApplicationStage = applicationStage;
                    }
                    var form = await formService.GetApplicationFormsByProgramId(program.Id);
                    if (form.Status && form?.Data != null)
                    {
                        var applicationForm = stage.Data as ApplicationForm;
                        program.ApplicationForm = applicationForm;
                    }
                    var mappedResponse = _mapper.Map<ApplicationProgramDto>(program);
                    return Result.Success<ProgramService>($"Application forms retrieved successfully", mappedResponse);
                }
                else
                {
                    return Result.Failure<ProgramService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ProgramService>($"Id: {id}", ex);
            }
        }

        public async Task<Result> GetByTitle(string title)
        {
            try
            {
                if (_context.ApplicationPrograms != null)
                {
                    var program = await _context.ApplicationPrograms.FirstOrDefaultAsync(c => c.Title == title);
                    if (program == null || string.IsNullOrEmpty(program?.Id))
                    {
                        return Result.Failure<ProgramService>($"No record found");
                    }
                    var mappedResponse = _mapper.Map<ApplicationProgramDto>(program);
                    return Result.Success<ProgramService>($"Application programs retrieved successfully", mappedResponse);
                }
                else
                {
                    return Result.Failure<ProgramService>($"Invalid Table");
                }
            }
            catch (Exception ex)
            {
                return Result.Exception<ProgramService>($"Title: {title}", ex);
            }
        }

        private static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationProgram, ApplicationProgramDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }
    }
}
