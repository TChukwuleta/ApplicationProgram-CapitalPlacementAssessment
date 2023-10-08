using ApplicationProgram_CapitalPlacementAssessment.Context;
using ApplicationProgram_CapitalPlacementAssessment.Core;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ApplicationProgram_CapitalPlacementAssessment.Services
{
    public class ProgramService : IProgramService
    {
        private readonly ApplicationDbContext _context;
        public ProgramService()
        {
            _context = new ApplicationDbContext();
        }
        public async Task CreateProgram(string title, string description)
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

                };
                await _context.ApplicationPrograms.AddAsync(entity);
                await _context.SaveChangesAsync();
                Console.WriteLine("Application program created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating application program. {ex?.Message ?? ex?.InnerException?.Message}");
            }
        }

        public async Task GetAllProgram()
        {
            try
            {
                if (_context.ApplicationPrograms != null)
                {
                    var programs = await _context.ApplicationPrograms.ToListAsync();
                    if (programs == null || !programs.Any())
                    {
                        Console.WriteLine($"No record found");
                    }
                    Console.WriteLine($"Application programs retrieved successfully. {JsonConvert.SerializeObject(programs)}");
                }
                else
                {
                    Console.WriteLine($"No table found for application program");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving application programs. {ex?.Message ?? ex?.InnerException?.Message}");
            }
        }

        public async Task GetById(string id)
        {
            try
            {
                if (_context.ApplicationPrograms != null)
                {
                    var program = await _context.ApplicationPrograms.FirstOrDefaultAsync(c => c.Id == id);
                    if (program == null || string.IsNullOrEmpty(program?.Id))
                    {
                        Console.WriteLine($"Invalid program specified");
                    }
                    Console.WriteLine($"Application program retrieved successfully. {JsonConvert.SerializeObject(program)}");
                }
                else
                {
                    Console.WriteLine($"No table found for application program");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving application program. {ex?.Message ?? ex?.InnerException?.Message}");
            }
        }

        public async Task GetByTitle(string title)
        {
            try
            {
                if (_context.ApplicationPrograms != null)
                {
                    var program = await _context.ApplicationPrograms.FirstOrDefaultAsync(c => c.Title == title);
                    if (program == null || string.IsNullOrEmpty(program?.Id))
                    {
                        Console.WriteLine($"Invalid program specified");
                    }
                    Console.WriteLine($"Application program retrieved successfully. {JsonConvert.SerializeObject(program)}");
                }
                else
                {
                    Console.WriteLine($"No table found for application program");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving application program. {ex?.Message ?? ex?.InnerException?.Message}");
            }
        }

        public async Task UpdateProgram(string id, string title, string description)
        {
            try
            {
                if (_context.ApplicationPrograms != null)
                {
                    var program = await _context.ApplicationPrograms.FirstOrDefaultAsync(c => c.Id == id);
                    if (program == null || string.IsNullOrEmpty(program?.Id))
                    {
                        Console.WriteLine($"Invalid program specified");
                    }
                    program.Title = title;
                    program.Description = description;
                    await _context.SaveChangesAsync();
                    Console.WriteLine($"Application program updated successfully");
                }
                else
                {
                    Console.WriteLine($"No table found for application program");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating application program. {ex?.Message ?? ex?.InnerException?.Message}");
            }
        }
    }
}
