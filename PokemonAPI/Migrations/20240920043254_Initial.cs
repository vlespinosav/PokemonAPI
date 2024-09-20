using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPokemon = table.Column<int>(type: "int", nullable: false),
                    NombrePokemon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPokemon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonDetalle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonEspecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorPokemon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Habitat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPokemon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlEvolution = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonEspecies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonEvolucion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePokemonEvolucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPokemon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonEvolucion", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonDetalle");

            migrationBuilder.DropTable(
                name: "PokemonEspecies");

            migrationBuilder.DropTable(
                name: "PokemonEvolucion");
        }
    }
}
