using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Modelo
{
    public class PokemonDetail
    {
        public int Id { get; set; }
        public int NumeroPokemon { get; set; }
        public string  NombrePokemon { get; set; }
        public string TipoPokemon { get; set; }
    }
}
