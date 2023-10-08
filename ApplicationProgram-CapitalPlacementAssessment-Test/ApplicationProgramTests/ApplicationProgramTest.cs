using ApplicationProgram_CapitalPlacementAssessment.Common;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using ApplicationProgram_CapitalPlacementAssessment_Test.Services;
using Moq;

namespace ApplicationProgram_CapitalPlacementAssessment_Test.ApplicationProgramTests
{
    public class ApplicationProgramTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        public ApplicationProgramTest()
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
        public async Task UpdateApplicationProgram_RetunsSuccess()
        {
            var handler = new ApplicationProgramHelper();
            var result = handler.UpdateApplicationProgram(Guid.NewGuid().ToString(), "Test", "Testing application program creation", _unitOfWork.Object);
            Assert.NotNull(result);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetApplicationProgramById_CorrectId_RetunsSuccess()
        {
            var programId = "cd2a7fa5-99e6-4057-95cc-22175dde6c0d";
            var handler = new ApplicationProgramHelper();
            var result = handler.GetApplicationProgramById(programId, _unitOfWork.Object);
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetApplicationProgramById_IncorrectId_RetunsFalse()
        {
            var handler = new ApplicationProgramHelper();
            var result = handler.GetApplicationProgramById(Guid.NewGuid().ToString(), _unitOfWork.Object);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetApplicationProgramDetailsById_CorrectId_RetunsSuccess()
        {
            var programId = "cd2a7fa5-99e6-4057-95cc-22175dde6c0d";
            var handler = new ApplicationProgramHelper();
            var result = handler.GetApplicationProgramDetailsById(programId, _unitOfWork.Object);
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetApplicationProgramDetailsById_IncorrectId_RetunsFalse()
        {
            var handler = new ApplicationProgramHelper();
            var result = handler.GetApplicationProgramDetailsById(Guid.NewGuid().ToString(), _unitOfWork.Object);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetApplicationProgramsByTitle_CorrectId_RetunsSuccess()
        {
            var title = "Test";
            var handler = new ApplicationProgramHelper();
            var result = handler.GetApplicationProgramByTitle(title, _unitOfWork.Object);
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetApplicationProgramTitleById_IncorrectId_RetunsFalse()
        {
            var handler = new ApplicationProgramHelper();
            var result = handler.GetApplicationProgramByTitle(Guid.NewGuid().ToString(), _unitOfWork.Object);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetApplicationPrograms_CorrectId_RetunsSuccess()
        {
            var handler = new ApplicationProgramHelper();
            var result = handler.GetAllApplicationProgram(_unitOfWork.Object);
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetApplicationProgramDetails_CorrectId_RetunsSuccess()
        {
            var handler = new ApplicationProgramHelper();
            var result = handler.GetAllApplicationProgramDetails(_unitOfWork.Object);
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }
    }
}
