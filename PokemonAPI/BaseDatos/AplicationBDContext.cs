using Microsoft.EntityFrameworkCore;
using PokemonAPI.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.BaseDatos
{
    public class AplicationBDContext : DbContext
    {
        public AplicationBDContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EvolucionPokemon> PokemonEvolucion { get; set; }
        public DbSet<PokemonDetail> PokemonDetalle { get; set; }
        public DbSet<PokemonEspecie> PokemonEspecies { get; set; }
    }
}
