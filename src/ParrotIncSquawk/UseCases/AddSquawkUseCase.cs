
using ParrotIncSquawk.Infrastructure.Squawks.CreateSquawk;

namespace ParrotIncSquawk.UseCases
{
    public class AddSquawkUseCase(
        ICreateSquawkRepository createSquawkRepository,
        ILogger<AddSquawkUseCase> logger
    ) : IAddSquawkUseCase
    {
        public async Task<Guid> AddSquawk(Guid userId, string text, CancellationToken cancellationToken)
        {
            var command = new CreateSquawkCommand(userId, text);
            var result = await createSquawkRepository.Handle(command, cancellationToken);
            logger.LogInformation("Squawk created by UserID : {userId}, Text : {text}", userId, text);
            return result.Id;
        }
    }
}
