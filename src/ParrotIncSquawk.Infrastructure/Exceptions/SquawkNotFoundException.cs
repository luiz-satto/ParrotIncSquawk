using BuildingBlocks.Exceptions;

namespace ParrotIncSquawk.Infrastructure.Exceptions
{
    public class SquawkNotFoundException(Guid Id) : NotFoundException("Squawk", Id)
    {

    }
}
