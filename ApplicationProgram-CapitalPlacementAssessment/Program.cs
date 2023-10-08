using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using ApplicationProgram_CapitalPlacementAssessment.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices(services => {
        services.AddSingleton<IProgramService, ProgramService>();
        services.AddSingleton<IApplicationFormService, ApplicationFormService>();
        services.AddSingleton<IProfileService, ProfileService>();
        services.AddSingleton<IApplicationStageService, ApplicationStageService>();
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
    }).Build();
var app = host.Services.GetRequiredService<IUnitOfWork>();
app.Run();

PrintOptions();

// Home
void PrintOptions()
{
    Console.WriteLine("Please choose from one of the following options...");
    Console.WriteLine("1. Application Program");
    Console.WriteLine("2. Application Form"); 
    Console.WriteLine("1. Application Stage");
    Console.WriteLine("2. Profile");
}
