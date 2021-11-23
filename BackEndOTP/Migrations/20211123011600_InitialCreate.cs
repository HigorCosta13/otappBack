using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndOTP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hospitals",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    hospital = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospitals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    cpf = table.Column<string>(type: "TEXT", nullable: true),
                    dateDeNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    senha = table.Column<string>(type: "TEXT", nullable: true),
                    imagem = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vacinacaos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    nameVacina = table.Column<string>(type: "TEXT", nullable: true),
                    dose = table.Column<int>(type: "INTEGER", nullable: false),
                    atual = table.Column<int>(type: "INTEGER", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dateProx = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacinacaos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "consultas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    usuarioID = table.Column<int>(type: "INTEGER", nullable: false),
                    hospitalID = table.Column<int>(type: "INTEGER", nullable: false),
                    hopsital = table.Column<string>(type: "TEXT", nullable: true),
                    especialidade = table.Column<string>(type: "TEXT", nullable: true),
                    data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    hora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    hopsitalname = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultas", x => x.id);
                    table.ForeignKey(
                        name: "FK_consultas_hospitals_hopsitalname",
                        column: x => x.hopsitalname,
                        principalTable: "hospitals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_consultas_usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_consultas_hopsitalname",
                table: "consultas",
                column: "hopsitalname");

            migrationBuilder.CreateIndex(
                name: "IX_consultas_usuarioID",
                table: "consultas",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_email_cpf",
                table: "usuarios",
                columns: new[] { "email", "cpf" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consultas");

            migrationBuilder.DropTable(
                name: "vacinacaos");

            migrationBuilder.DropTable(
                name: "hospitals");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
