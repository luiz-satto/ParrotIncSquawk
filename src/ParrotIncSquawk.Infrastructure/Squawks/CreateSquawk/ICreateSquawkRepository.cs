using BuildingBlocks.CQRS;

namespace ParrotIncSquawk.Infrastructure.Squawks.CreateSquawk
{
    public record CreateSquawkCommand(
        Guid UserId,
        string Text
    ) : ICommand<CreateSquawkResult>;

    public record CreateSquawkResult(Guid Id);

    public interface ICreateSquawkRepository : ICommandHandler<CreateSquawkCommand, CreateSquawkResult>
    {
    }
}
