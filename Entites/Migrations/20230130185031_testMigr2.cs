using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entites.Migrations
{
    /// <inheritdoc />
    public partial class testMigr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Joueurs",
                columns: new[] { "Id", "EquipeForeignKey", "NomJoueur", "PrenomJoueur" },
                values: new object[] { 3, 2, "Nom3", "Prenom3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Joueurs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
