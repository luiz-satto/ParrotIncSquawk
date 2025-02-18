using Microsoft.EntityFrameworkCore;
using ParrotIncSquawk.Infrastructure.Exceptions;
using ParrotIncSquawk.Infrastructure.Persistence;

namespace ParrotIncSquawk.Infrastructure.Squawks.GetSquawks
{
    public class GetSquawkByIdRepository(SquawkContext context) : IGetSquawkByIdRepository
    {
        public async Task<GetSquawkByIdResult> Handle(GetSquawkByIdQuery query, CancellationToken cancellationToken)
        {
            var squawk = await context.Squawks
                .FirstOrDefaultAsync(x => x.SquawkId == query.SquawkId, cancellationToken);

            return squawk is null
                ? throw new SquawkNotFoundException(query.SquawkId)
                : new GetSquawkByIdResult(squawk);
        }
    }
}
