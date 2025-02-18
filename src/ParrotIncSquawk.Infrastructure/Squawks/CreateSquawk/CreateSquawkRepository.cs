using BuildingBlocks.Exceptions;
using ParrotIncSquawk.Infrastructure.Models;
using ParrotIncSquawk.Infrastructure.Persistence;

namespace ParrotIncSquawk.Infrastructure.Squawks.CreateSquawk
{
    public class CreateSquawkRepository(SquawkContext context) : ICreateSquawkRepository
    {
        public async Task<CreateSquawkResult> Handle(CreateSquawkCommand command, CancellationToken cancellationToken)
        {
            if (command.Text == null)
            {
                throw new BadRequestException("Text is required.");
            }

            if (command.Text.Length > 400)
            {
                throw new BadRequestException("Max 400 characters per Squawk.");
            }

            if (command.Text.Contains("Tweet", StringComparison.CurrentCultureIgnoreCase) ||
                command.Text.Contains("Twitter", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new BadRequestException("Squawks containing 'Tweet' or 'Twitter' are not allowed.");
            }

            var squawk = context.Squawks
                .FirstOrDefault(x => x.UserId == command.UserId
                && x.Text.Equals(command.Text, StringComparison.CurrentCultureIgnoreCase));

            if (squawk != null)
            {
                throw new BadRequestException("Duplicate Squawks are not allowed.");
            }

            squawk = new Squawk
            {
                SquawkId = Guid.NewGuid(),
                UserId = command.UserId,
                Text = command.Text,
                SquawkDate = DateTime.Now,
            };

            context.Squawks.Add(squawk);
            await context.SaveChangesAsync(cancellationToken);
            return new CreateSquawkResult(squawk.SquawkId);
        }
    }
}
