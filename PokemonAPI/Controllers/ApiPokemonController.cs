using log4net.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokemonAPI.BaseDatos;
using PokemonAPI.Modelo;
using PokemonAPI.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPI.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPokemonController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly AplicationBDContext context;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public ApiPokemonController(ILogger<ApiPokemonController> logger, IConfiguration configuration, AplicationBDContext context)
        {
            this.configuration = configuration;
            this.context = context;
            this._logger = logger;

        }

    

        /// <summary>
        /// Metodo para obtener un Pokemon
        /// </summary>
        /// <param name="NombrePokemon"></param>
        /// <returns></returns>
        [HttpGet("Pokemon")]
        public async Task<IEnumerable<PokemonDetail>> GetPokemon(string NombrePokemon)
        {
            _logger.LogInformation("Inicia Busqueda de Pokemon Form");
            List<PokemonDetail> listaPokemon = new List<PokemonDetail>();
            PokemonJson obj = new PokemonJson();

            string Url = configuration["Url"];

            string urlForm = await obj.ObtenerUrl(Url, Tipo.UrlFrom);
            listaPokemon = (List<PokemonDetail>)await obj.ObtenerPokemonForm(urlForm);

            _logger.LogInformation("Se obtuvo Pokemon form");
            return listaPokemon;
        }


        /// <summary>
        /// Metodo para Obtener la Evolucion de un Pokemon
        /// </summary>
        /// <param name="NombrePokemon"></param>
        /// <returns></returns>
        [HttpGet("Evolucion")]
        public async Task<IEnumerable<EvolucionPokemon>> GetEvolucion(string NombrePokemon)
        {
            _logger.LogInformation("Inicia Busqueda de Pokemon Evolucion");
            List<EvolucionPokemon> listaPokemon = new List<EvolucionPokemon>();
            PokemonJson obj = new PokemonJson();

            string Url = configuration["Url"];

            string urlEvoluion = await obj.ObtenerUrl(Url, Tipo.UrlEvolucion);
            listaPokemon = (List<EvolucionPokemon>)await obj.ObtenerPokemonEvolution(urlEvoluion);

            _logger.LogInformation("Se obtuvo Pokemon Evolution");
            return listaPokemon;
        }

        /// <summary>
        /// Metodo para guardar un poquemon
        /// </summary>
        /// <param name="pokemonDetail"></param>
        /// <returns></returns>
        [HttpPost("GuardarPokemon")]
        public async Task<ActionResult<PokemonDetail>> GuardarPokemon(PokemonDetail pokemonDetail)
        {
            context.Add(pokemonDetail);
            await context.SaveChangesAsync();
            _logger.LogInformation("Se Guardo Pokemon");
            return Ok();

        }

    }
}
