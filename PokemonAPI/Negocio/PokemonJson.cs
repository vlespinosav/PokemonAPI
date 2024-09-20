using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokemonAPI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPI.Negocio
{
    public class PokemonJson
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public PokemonJson(ILogger<PokemonJson> logger)
        {
            this._logger = logger;
        }

        public PokemonJson()
        {
        }

        public async Task<IEnumerable<PokemonAll>> PokemonAll(string Url)
        {

              List<PokemonAll> listaPokemon = new List<PokemonAll>();
                int Id = 0;
                string urlForm = string.Empty;
                string urlSpecies = string.Empty;
                string urlEvolution = string.Empty;
                var httpClient = new HttpClient();
            try
            {

                //Se consume pokeapi.co
                var response = await httpClient.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var objApi = JsonConvert.DeserializeObject<PokemonAll>(responseContent);

                    //Obtenemos  urlForm
                    foreach (var item in objApi.forms)
                    {
                        urlForm = item.url;
                    }
                    //Obtenemos Datos Pokemon Form
                    List<PokemonDetail> pokemonDetail = (List<PokemonDetail>)await ObtenerPokemonForm(urlForm);

                    //Obtenemos  urlSpecies
                    urlSpecies = objApi.species.url;
                    //Obtenemos Datos Pokemon Species
                    List<PokemonEspecie> pokemonSpecies = (List<PokemonEspecie>)await ObtenerPokemonSpecies(urlSpecies);

                    //Obtenemos  urlEvolution
                    foreach (var item in pokemonSpecies)
                    {
                        urlEvolution = item.UrlEvolution;
                    }

                    //Obtenemos Datos Pokemon Species
                    List<EvolucionPokemon> pokemonEvolution = (List<EvolucionPokemon>)await ObtenerPokemonEvolution(urlEvolution);

                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Ocurrio un error en PokemonAll" + ex.ToString());
            }

            return listaPokemon;
        }

        public async Task<IEnumerable<PokemonDetail>> ObtenerPokemonForm(string Url)
        {
            List<PokemonDetail> listaPokemonForm = new List<PokemonDetail>();
            string Tipo = string.Empty;
            var httpClient = new HttpClient();

            try
            {
                //Se consume pokeapi.co
                var response = await httpClient.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var objApi = JsonConvert.DeserializeObject<PokemonForm>(responseContent);

                    //Obtenemos tipo de POkemon
                    foreach (var item in objApi.types)
                    {
                        Tipo = item.type.name;
                    }

                    //LLenamos nueva lista de pokemon con los datos que nesesitamos
                    listaPokemonForm.Add(new PokemonDetail
                    {
                        Id = objApi.id,
                        NumeroPokemon = objApi.order,
                        NombrePokemon = objApi.name,
                        TipoPokemon = Tipo
                    });

                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Ocurrio un error en PokemonForm" + ex.ToString());
            }

            return listaPokemonForm;
        }

        public async Task<IEnumerable<PokemonEspecie>> ObtenerPokemonSpecies(string Url)
        {
            List<PokemonEspecie> listaPokemonEspecies = new List<PokemonEspecie>();
            string UrlEvolution = string.Empty;
            var httpClient = new HttpClient();

            try
            {
                //Se consume pokeapi.co
                var response = await httpClient.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var objApi = JsonConvert.DeserializeObject<PokemonSpecies>(responseContent);
                    //listaPokemonSpecies = JsonConvert.DeserializeObject<List<PokemonSpecies>>(responseContent);

                    listaPokemonEspecies.Add(new PokemonEspecie
                    {
                        UrlEvolution = objApi.evolution_chain.url
                    });

                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Ocurrio un error en PokemonSpecies" + ex.ToString());
            }
            return listaPokemonEspecies;
        }

        public async Task<IEnumerable<EvolucionPokemon>> ObtenerPokemonEvolution(string Url)
        {
            List<EvolucionPokemon> listaPokemonEvolucion = new List<EvolucionPokemon>();
            string UrlEvolution = string.Empty;
            string Evolucion = string.Empty;
            var httpClient = new HttpClient();

            try
            {
                //Se consume pokeapi.co
                var response = await httpClient.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var objApi = JsonConvert.DeserializeObject<EvolutionChain>(responseContent);

                    //Obtenemos nombre evolucion
                    foreach (var item in objApi.chain.evolves_to)
                    {
                        foreach (var evo in item.evolves_to)
                        {
                            Evolucion = evo.species.name;
                        }
                    }

                    listaPokemonEvolucion.Add(new EvolucionPokemon
                    {
                        Id = objApi.id,
                        NombrePokemonEvolucion = Evolucion

                    });

                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Ocurrio un error en PokemonEvolution" + ex.ToString());
            }
            return listaPokemonEvolucion;
        }

        public async Task<string> ObtenerUrl(string Url, Tipo tipoUrl)
        {
       
            List<PokemonAll> listaPokemon = new List<PokemonAll>();
            int Id = 0;
            string UrlOK = string.Empty;
            string urlForm = string.Empty;
            string urlSpecies = string.Empty;
            string urlEvolution = string.Empty;
            var httpClient = new HttpClient();

            try
            {
                //Se consume pokeapi.co
                var response = await httpClient.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var objApi = JsonConvert.DeserializeObject<PokemonAll>(responseContent);
                    switch (tipoUrl)
                    {
                        case Tipo.UrlFrom:
                            //Obtenemos  urlForm
                            foreach (var item in objApi.forms)
                            {
                                urlForm = item.url;
                            }

                            //Obtenemos Datos Pokemon Form                    
                            UrlOK = urlForm;
                            break;

                        case Tipo.UrlEspecies:

                            //Obtenemos  urlSpecies
                            urlSpecies = objApi.species.url;
                            UrlOK = urlSpecies;
                            break;

                        case Tipo.UrlEvolucion:

                            urlSpecies = objApi.species.url;
                            //Obtenemos Datos Pokemon Species
                            List<PokemonEspecie> pokemonSpecies = (List<PokemonEspecie>)await ObtenerPokemonSpecies(urlSpecies);
                            //Obtenemos  urlEvolution
                            foreach (var item in pokemonSpecies)
                            {
                                urlEvolution = item.UrlEvolution;
                            }
                            UrlOK = urlEvolution;
                            break;

                        default:
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Ocurrio un error en ObtenerUrl" + ex.ToString());
            }

            return UrlOK;
        }

        public int ObtenerIdUrls(string Url)
        {
            int IdPokemon = 0;
            var valores = Url.Split('/');
            var tamano= valores.Length;
            //var server = valores[1].Split('=')
            IdPokemon = int.Parse(valores[tamano-2]);

            return IdPokemon;
        }

    }
}
