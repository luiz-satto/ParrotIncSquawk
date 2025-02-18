using Moq;
using ParrotIncSquawk.Controllers;
using ParrotIncSquawk.Tests.Extensions;
using ParrotIncSquawk.UseCases;
using System.Security.Claims;

namespace ParrotIncSquawk.Tests.Controllers
{
    [TestFixture]
    public class ParrotIncSquawkControllerTest()
    {
        private ParrotIncSquawkController Controller { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<IAddSquawkUseCase> addSquawkUseCase = new();
            Mock<IGetSquawksUseCase> getSquawksUseCase = new();
            Controller = new ParrotIncSquawkController(addSquawkUseCase.Object, getSquawksUseCase.Object);
        }

        [Test]
        public async Task CreateSquawk_ShouldAddNewSquawk()
        {
            // Arrange
            string text = "Test 1";
            var claims = new Claim(ClaimTypes.NameIdentifier, "7d08d372-4cb6-4963-85e0-001b8f95d760");
            Controller.InitializeClaims(claims);

            // Act
            var squawk = await Controller.AddSquawk(text, default);

            // Assert
            Assert.That(Guid.TryParse(squawk.ToString(), out Guid guidResult), Is.True);
        }
    }
}