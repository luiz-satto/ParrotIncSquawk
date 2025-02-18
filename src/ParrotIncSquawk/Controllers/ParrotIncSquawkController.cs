using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using ParrotIncSquawk.Infrastructure.Models;
using ParrotIncSquawk.Extensions;
using ParrotIncSquawk.UseCases;

namespace ParrotIncSquawk.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public sealed class ParrotIncSquawkController(
        IAddSquawkUseCase addSquawkUseCase,
        IGetSquawksUseCase getSquawksUseCase
    ) : ControllerBase
    {
        /// <summary>
        /// Returns a list of squawks
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Squawk>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Squawk>> Get(CancellationToken cancellationToken) =>
            await getSquawksUseCase.GetSquawks(cancellationToken);

        /// <summary>
        /// Gets a squawk by Id
        /// </summary>
        /// <param name="id">Squawk Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Squawk), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Squawk> Get(Guid id, CancellationToken cancellationToken) =>
            await getSquawksUseCase.GetSquawkById(id, cancellationToken);

        /// <summary>
        /// Adds a new squawks into db
        /// </summary>
        /// <param name="text">Squawk text</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableRateLimiting(Consts.TwentySecondIntervalPolicy)] // Limited to one post per 20-second interval
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Guid> AddSquawk([FromBody] string text, CancellationToken cancellationToken) =>
            await addSquawkUseCase.AddSquawk(User.GetUserId(), text, cancellationToken);
    }
}
