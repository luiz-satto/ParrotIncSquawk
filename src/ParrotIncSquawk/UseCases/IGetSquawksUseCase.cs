using ParrotIncSquawk.Infrastructure.Models;

namespace ParrotIncSquawk.UseCases
{
    public interface IGetSquawksUseCase
    {
        public Task<IEnumerable<Squawk>> GetSquawks(CancellationToken cancellationToken);
        public Task<Squawk> GetSquawkById(Guid squawkId, CancellationToken cancellationToken);
    }
}
