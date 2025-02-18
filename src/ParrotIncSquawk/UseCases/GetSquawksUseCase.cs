using ParrotIncSquawk.Infrastructure.Models;
using ParrotIncSquawk.Infrastructure.Squawks.GetSquawks;

namespace ParrotIncSquawk.UseCases
{
    public class GetSquawksUseCase(
        IGetSquawksRepository getSquawksRepository,
        IGetSquawkByIdRepository getSquawkByIdRepository
    ) : IGetSquawksUseCase
    {

        public async Task<IEnumerable<Squawk>> GetSquawks(CancellationToken cancellationToken)
        {
            var query = new GetSquawksQuery();
            var result = await getSquawksRepository.Handle(query, cancellationToken);
            return result.Squawks;
        }

        public async Task<Squawk> GetSquawkById(Guid squawkId, CancellationToken cancellationToken)
        {
            var query = new GetSquawkByIdQuery(squawkId);
            var result = await getSquawkByIdRepository.Handle(query, cancellationToken);
            return result.Squawk;
        }
    }
}
