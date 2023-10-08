using ApplicationProgram_CapitalPlacementAssessment.Common;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using ApplicationProgram_CapitalPlacementAssessment_Test.Services;
using Moq;

namespace ApplicationProgram_CapitalPlacementAssessment_Test.ApplicationStageTests
{
    public class ApplicationStageTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        public ApplicationStageTest()
        {
            _unitOfWork = MockkUnitOfWork.GetUnitOfWorkMock();
        }

        [Fact]
        public async Task CreateApplicationProgram_RetunsSuccess()
        {
            var handler = new ApplicationProgramHelper();
            var result = handler.CreateApplicationProgram("Test", "Testing application program creation", _unitOfWork.Object);
            Assert.NotNull(result);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task UpdateApplicationStage_RetunsSuccess()
        {
            var handler = new ApplicationStageHelper();
            var result = handler.UpdateApplicationProgramWithApplicationStage(Guid.NewGuid().ToString(), "Test", _unitOfWork.Object);
            Assert.NotNull(result);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetApplicationStageById_CorrectId_RetunsSuccess()
        {
            var programId = "cd2a7fa5-99e6-4057-95cc-22175dde6c0d";
            var handler = new ApplicationStageHelper();
            var result = handler.GetApplicationStageById(programId, _unitOfWork.Object);
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetApplicationStageById_IncorrectId_RetunsFalse()
        {
            var handler = new ApplicationStageHelper();
            var result = handler.GetApplicationStageById(Guid.NewGuid().ToString(), _unitOfWork.Object);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetApplicationStageByProgramId_CorrectId_RetunsSuccess()
        {
            var programId = "cd2a7fa5-99e6-4057-95cc-22175dde6c0d";
            var handler = new ApplicationStageHelper();
            var result = handler.GetApplicationStageByApplicationProgramId(programId, _unitOfWork.Object);
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetApplicationStageByProgramId_IncorrectId_RetunsFalse()
        {
            var handler = new ApplicationStageHelper();
            var result = handler.GetApplicationStageByApplicationProgramId(Guid.NewGuid().ToString(), _unitOfWork.Object);
            Assert.Null(result);
        }
        [Fact]
        public async Task GetApplicationStages_RetunsSuccess()
        {
            var handler = new ApplicationStageHelper();
            var result = handler.GetAllApplicationStages(_unitOfWork.Object);
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }
    }
}
