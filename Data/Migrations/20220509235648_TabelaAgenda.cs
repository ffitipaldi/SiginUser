using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiginUser.Data.Migrations
{
    public partial class TabelaAgenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Usuarios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPerfil = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CpfProfissional = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DataAgenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraAgenda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAgendaDetran = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraAgendaDetran = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CpfCandidato = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NomeCandidato = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmailCandidato = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TipoProcesso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StatusExMedico = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StatusExPsico = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
