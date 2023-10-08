﻿using ApplicationProgram_CapitalPlacementAssessment.Core;
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

            var mockUnitOfWOrk = new Mock<IUnitOfWork>();
            mockUnitOfWOrk.SetupGet(u => u.ProgramService).Returns(programServiceMock.Object);
            mockUnitOfWOrk.Setup(c => c.ProgramService.CreateProgram(title, description));
            return mockUnitOfWOrk;
        }
    }
}
