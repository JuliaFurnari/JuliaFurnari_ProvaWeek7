using Microsoft.EntityFrameworkCore.Migrations;

namespace Week7.Day5.Rubrica.RepositoryEF.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Indirizzo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipologia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Via = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Città = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cap = table.Column<int>(type: "int", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContattoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indirizzo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Indirizzo_Contatto_ContattoId",
                        column: x => x.ContattoId,
                        principalTable: "Contatto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Indirizzo_ContattoId",
                table: "Indirizzo",
                column: "ContattoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indirizzo");

            migrationBuilder.DropTable(
                name: "Contatto");
        }
    }
}
