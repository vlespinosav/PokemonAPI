﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Modelo
{
    public class EvolutionChain
    {
        public object baby_trigger_item { get; set; }
        public Chain chain { get; set; }
        public int id { get; set; }
    }

    public class Chain
    {
        public List<object> evolution_details { get; set; }
        public List<EvolvesTo> evolves_to { get; set; }
        public bool is_baby { get; set; }
        public Species species { get; set; }
    }

    public class EvolutionDetail
    {
        public object gender { get; set; }
        public object held_item { get; set; }
        public object item { get; set; }
        public object known_move { get; set; }
        public object known_move_type { get; set; }
        public object location { get; set; }
        public object min_affection { get; set; }
        public object min_beauty { get; set; }
        public int? min_happiness { get; set; }
        public object min_level { get; set; }
        public bool needs_overworld_rain { get; set; }
        public object party_species { get; set; }
        public object party_type { get; set; }
        public object relative_physical_stats { get; set; }
        public string time_of_day { get; set; }
        public object trade_species { get; set; }
        public Trigger trigger { get; set; }
        public bool turn_upside_down { get; set; }
    }

    public class EvolvesTo
    {
        public List<EvolutionDetail> evolution_details { get; set; }
        public List<EvolvesTo> evolves_to { get; set; }
        public bool is_baby { get; set; }
        public Species species { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
        public string url { get; set; }
    }

  

    public class Species
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Trigger
    {
        public string name { get; set; }
        public string url { get; set; }
    }


}
