using BuildingBlocks.Exceptions;
using Microsoft.EntityFrameworkCore;
using ParrotIncSquawk.Infrastructure.Persistence;

namespace ParrotIncSquawk.Infrastructure.Squawks.GetSquawks
{
    public class GetSquawksRepository(SquawkContext context) : IGetSquawksRepository
    {
        public async Task<GetSquawksResult> Handle(GetSquawksQuery query, CancellationToken cancellationToken)
        {
            var skip = (query.PageNumber - 1) * query.PageSize;
            var squawks = await context.Squawks
                .Skip(skip ?? 1)
                .Take(query.PageSize ?? 10)
                .ToListAsync(cancellationToken);

            return squawks is null
                ? throw new BadRequestException("No squawks found.")
                : new GetSquawksResult(squawks);
        }
    }
}
