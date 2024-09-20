using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Modelo
{
    public class PokemonForm
    {
        public string form_name { get; set; }
        public List<object> form_names { get; set; }
        public int form_order { get; set; }
        public int id { get; set; }
        public bool is_battle_only { get; set; }
        public bool is_default { get; set; }
        public bool is_mega { get; set; }
        public string name { get; set; }
        public List<object> names { get; set; }
        public int order { get; set; }
        public Pokemon pokemon { get; set; }
        public Sprites sprites { get; set; }
        public List<Type> types { get; set; }
        public VersionGroup version_group { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Pokemon
    {
        public string name { get; set; }
        public string url { get; set; }
    }



    public class Sprites
    {
        public string back_default { get; set; }
        public string back_female { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_female { get; set; }
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public class Type
    {
        public int slot { get; set; }
        public Type2 type { get; set; }
    }

    public class Type2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class VersionGroup
    {
        public string name { get; set; }
        public string url { get; set; }
    }


}
