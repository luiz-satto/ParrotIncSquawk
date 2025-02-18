using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using ParrotIncSquawk.Infrastructure.Persistence;
using ParrotIncSquawk.Infrastructure.Squawks.CreateSquawk;
using ParrotIncSquawk.Tests.Extensions;
using ParrotIncSquawk.UseCases;

namespace ParrotIncSquawk.Tests.UseCases
{
    [TestFixture]
    public class AddSquawkUseCaseTest
    {
        private IAddSquawkUseCase UseCase { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<SquawkContext> mockContext = new();
            mockContext.Setup(x => x.Squawks).ReturnsDbSet(TestDataHelper.GetFakeSquawkList());

            CreateSquawkRepository mockRepo = new(mockContext.Object);
            Mock<ILogger<AddSquawkUseCase>> mockLogger = new();
            UseCase = new AddSquawkUseCase(mockRepo, mockLogger.Object);
        }

        [Test]
        public async Task CreateSquawk_ShouldAddNewSquawk()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var text = "Test 1";

            // Act
            var squawk = await UseCase.AddSquawk(userId, text, default);

            // Assert
            Assert.That(Guid.TryParse(squawk.ToString(), out Guid guidResult), Is.True);
        }

        [Test]
        public async Task CreateSquawk_ShouldNotAddNewSquawk()
        {
            // Arrange
            var userId = Guid.NewGuid();
            string text = TestDataHelper.GenerateRandomText(500);

            try
            {
                // Act
                var squawk = await UseCase.AddSquawk(userId, text, default);

                // Assert
                Assert.That(Guid.TryParse(squawk.ToString(), out Guid guidResult), Is.False);
            }
            catch (Exception ex)
            {
                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.EqualTo("Max 400 characters per Squawk."));
            }
        }
    }
}
