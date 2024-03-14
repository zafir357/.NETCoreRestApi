using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entites.Migrations
{
    /// <inheritdoc />
    public partial class ex042014 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomEquipe = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Joueurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomJoueur = table.Column<string>(type: "TEXT", nullable: false),
                    PrenomJoueur = table.Column<string>(type: "TEXT", nullable: false),
                    EquipeForeignKey = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Joueurs_Equipes_EquipeForeignKey",
                        column: x => x.EquipeForeignKey,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Equipes",
                columns: new[] { "Id", "NomEquipe" },
                values: new object[,]
                {
                    { 1, "Manu" },
                    { 2, "PSG" }
                });

            migrationBuilder.InsertData(
                table: "Joueurs",
                columns: new[] { "Id", "EquipeForeignKey", "NomJoueur", "PrenomJoueur" },
                values: new object[,]
                {
                    { 1, 1, "Nom", "Prenom" },
                    { 2, 2, "Nom2", "Prenom2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Joueurs_EquipeForeignKey",
                table: "Joueurs",
                column: "EquipeForeignKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Joueurs");

            migrationBuilder.DropTable(
                name: "Equipes");
        }
    }
}
