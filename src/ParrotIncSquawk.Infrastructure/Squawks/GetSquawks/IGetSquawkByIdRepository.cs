using BuildingBlocks.CQRS;
using ParrotIncSquawk.Infrastructure.Models;

namespace ParrotIncSquawk.Infrastructure.Squawks.GetSquawks
{
    public record GetSquawkByIdQuery(Guid SquawkId) : IQuery<GetSquawkByIdResult>;
    public record GetSquawkByIdResult(Squawk Squawk);

    public interface IGetSquawkByIdRepository : IQueryHandler<GetSquawkByIdQuery, GetSquawkByIdResult>
    {
    }
}
