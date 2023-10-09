using ApplicationProgram_CapitalPlacementAssessment.Core;
using ApplicationProgram_CapitalPlacementAssessment.Core.Models;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using ApplicationProgram_CapitalPlacementAssessment.Services;
using Moq;

namespace ApplicationProgram_CapitalPlacementAssessment_Test.Services
{
    public static class MockkUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWorkMock()
        {
            string title = "Test";
            string description = "Testing the application";
            var programId = "cd2a7fa5-99e6-4057-95cc-22175dde6c0d";
            List<ApplicationProgram> programs = new List<ApplicationProgram>();
            var program = new ApplicationProgram { Title = "Testing", Description = "Testing", LocationTypeDesc = LocationType.FullyRemote.ToString(), ProgramTypeDesc = ProgramType.FullTime.ToString() };
            programs.Add(program);

            List<ApplicationStage> applicationStages = new List<ApplicationStage>();
            var applicationStage = new ApplicationStage { ApplicationProgramId = programId, Name = title };
            applicationStages.Add(applicationStage);

            List<ApplicationForm> applicationForms = new List<ApplicationForm>();
            var applicationForm = new ApplicationForm { ApplicationProgramId = programId };
            applicationForms.Add(applicationForm);


            // Application program mock
            var programServiceMock = new Mock<IProgramService>();
            programServiceMock
                .Setup(p => p.CreateProgram(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(Result.Success<ProgramService>("Application program created successfully"));

            programServiceMock
                .Setup(p => p.UpdateProgram(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(Result.Success<ProgramService>("Application program updated successfully"));

            programServiceMock
            .Setup(p => p.GetById(programId))
            .ReturnsAsync(Result.Success<ProgramService>($"Application programs retrieved successfully", program));

            programServiceMock
            .Setup(p => p.GetByTitle(title))
            .ReturnsAsync(Result.Success<ProgramService>($"Application programs retrieved successfully", program));

            programServiceMock
            .Setup(p => p.GetProgramDetailsById(programId))
            .ReturnsAsync(Result.Success<ProgramService>($"Application forms retrieved successfully", program));

            programServiceMock
            .Setup(p => p.GetAllProgram())
            .ReturnsAsync(Result.Success<ProgramService>($"Application programs retrieved successfully", programs));

            programServiceMock
            .Setup(p => p.GetAllProgramDetails())
            .ReturnsAsync(Result.Success<ProgramService>($"Application programs retrieved successfully", programs));


            // Application stage mock
            var stageServiceMock = new Mock<IApplicationStageService>();
            stageServiceMock
                .Setup(p => p.UpdateApplicationProgramWithApplicationStage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(Result.Success<ApplicationStageService>("Application program updated successfully with application form"));

            stageServiceMock
            .Setup(p => p.GetById(programId))
            .ReturnsAsync(Result.Success<ApplicationStageService>($"Application stage retrieved successfully", applicationStage));

            stageServiceMock
            .Setup(p => p.GetApplicationStagesByProgramId(programId))
            .ReturnsAsync(Result.Success<ApplicationStageService>($"Application stage retrieved successfully", applicationStage));

            stageServiceMock
            .Setup(p => p.GetAllProgramStages())
            .ReturnsAsync(Result.Success<ApplicationStageService>($"Application stages retrieved successfully", applicationStages));


            // Application form mock
            var stageFormMock = new Mock<IApplicationFormService>();
            stageFormMock
                .Setup(p => p.UpdateApplicationForm(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(Result.Success<ApplicationFormService>("Application program updated successfully with application form"));

            stageFormMock
            .Setup(p => p.GetById(programId))
            .ReturnsAsync(Result.Success<ApplicationFormService>($"Application form retrieved successfully", applicationForm));

            stageFormMock
            .Setup(p => p.GetApplicationFormsByProgramId(programId))
            .ReturnsAsync(Result.Success<ApplicationFormService>($"Application forms retrieved successfully", applicationForm));

            stageFormMock
            .Setup(p => p.GetAllApplicationForms())
            .ReturnsAsync(Result.Success<ApplicationFormService>($"Application forms retrieved successfully", applicationForm));


            var mockUnitOfWOrk = new Mock<IUnitOfWork>();
            mockUnitOfWOrk.SetupGet(u => u.ProgramService).Returns(programServiceMock.Object);
            mockUnitOfWOrk.SetupGet(u => u.ApplicationStageService).Returns(stageServiceMock.Object);
            mockUnitOfWOrk.SetupGet(u => u.ApplicationFormService).Returns(stageFormMock.Object);
            mockUnitOfWOrk.Setup(c => c.ProgramService.CreateProgram(title, description));
            return mockUnitOfWOrk;
        }
    }
}
