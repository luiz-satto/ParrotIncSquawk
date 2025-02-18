namespace ParrotIncSquawk.UseCases
{
    public interface IAddSquawkUseCase
    {
        public Task<Guid> AddSquawk(Guid userId, string text, CancellationToken cancellationToken);
    }
}
