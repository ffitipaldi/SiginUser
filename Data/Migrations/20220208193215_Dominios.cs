using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiginUser.Data.Migrations
{
    public partial class Dominios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dominios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sequencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dominios", x => x.Id);
                });
        }
    }
}
