using ApplicationProgram_CapitalPlacementAssessment.Common;
using ApplicationProgram_CapitalPlacementAssessment.Context;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using ApplicationProgram_CapitalPlacementAssessment.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Appsettings connection
/*IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
    .AddJsonFile("appsettings").Build();*/

IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices(services => {
        services.AddSingleton<ApplicationDbContext>();
        services.AddSingleton<ApplicationProgramHelper>();
        //services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<IProgramService, ProgramService>();
        services.AddSingleton<IApplicationFormService, ApplicationFormService>();
        services.AddSingleton<IProfileService, ProfileService>();
        services.AddSingleton<IApplicationStageService, ApplicationStageService>();
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
    }).Build();
var app = host.Services.GetRequiredService<IUnitOfWork>();
app.Run();
