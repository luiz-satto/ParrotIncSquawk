using BuildingBlocks.CQRS;
using ParrotIncSquawk.Infrastructure.Models;

namespace ParrotIncSquawk.Infrastructure.Squawks.GetSquawks
{
    public record GetSquawksQuery(int? PageNumber = 1, int? PageSize = 100) : IQuery<GetSquawksResult>;
    public record GetSquawksResult(IEnumerable<Squawk> Squawks);

    public interface IGetSquawksRepository : IQueryHandler<GetSquawksQuery, GetSquawksResult>
    {
    }
}
