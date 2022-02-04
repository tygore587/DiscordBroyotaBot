using DiscordBot.Api.Common;
using DiscordBot.Api.Models;
using DiscordBot.Api.Models.Pokemons;
using DiscordBot.Domain.Pokemons.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBot.Api.Controllers.Pokemons
{
    [Authorize]
    [Route("pokemons")]
    public class PokemonsController : BaseController<PokemonsController>
    {
        private readonly FindPokemonByName findPokemonByName;

        public PokemonsController(ILogger<PokemonsController> logger, FindPokemonByName findPokemonByName) : base(logger)
        {
            this.findPokemonByName = findPokemonByName;
        }


        [HttpGet("search/{name}")]
        [Produces(MimeType.ApplicationJson)]
        [ProducesResponseType(typeof(PokemonBaseInfoResponse), StatusCodes.Status200OK)]
        public IActionResult GetFindByName([FromRoute] string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Provide name by path parameter.");

            var parameter = new FindPokemonByNameParameter(name);

            var pokemons = findPokemonByName.Execute(parameter);

            return Ok(pokemons.ToResponses());
        }
    }
}
