using ApplicationProgram_CapitalPlacementAssessment.Common.Helpers;
using ApplicationProgram_CapitalPlacementAssessment.Interfaces;
using ApplicationProgram_CapitalPlacementAssessment_Test.Services;
using Moq;

namespace ApplicationProgram_CapitalPlacementAssessment_Test.ApplicationFormTests
{
    public class ApplicationFormTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        public ApplicationFormTest()
        {
            _unitOfWork = MockkUnitOfWork.GetUnitOfWorkMock();
        }

        [Fact]
        public async Task UpdateApplicationForm_RetunsSuccess()
        {
            var handler = new ApplicationFormHelper();
            var result = handler.UpdateApplicationForm(Guid.NewGuid().ToString(), 1, _unitOfWork.Object);
            Assert.NotNull(result);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetApplicationFormById_CorrectId_RetunsSuccess()
        {
            var programId = "cd2a7fa5-99e6-4057-95cc-22175dde6c0d";
            var handler = new ApplicationFormHelper();
            var result = handler.GetApplicationFormById(programId, _unitOfWork.Object);
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetApplicationFormById_IncorrectId_RetunsFalse()
        {
            var handler = new ApplicationFormHelper();
            var result = handler.GetApplicationFormById(Guid.NewGuid().ToString(), _unitOfWork.Object);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetApplicationFormByProgramId_CorrectId_RetunsSuccess()
        {
            var programId = "cd2a7fa5-99e6-4057-95cc-22175dde6c0d";
            var handler = new ApplicationFormHelper();
            var result = handler.GetApplicationFormByProgramId(programId, _unitOfWork.Object);
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetApplicationFormByProgramId_IncorrectId_RetunsFalse()
        {
            var handler = new ApplicationFormHelper();
            var result = handler.GetApplicationFormByProgramId(Guid.NewGuid().ToString(), _unitOfWork.Object);
            Assert.Null(result);
        }
        [Fact]
        public async Task GetApplicationStages_RetunsSuccess()
        {
            var handler = new ApplicationFormHelper();
            var result = handler.GetAllApplicationForm(_unitOfWork.Object);
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.NotEmpty(result.Message);
        }
    }
}
