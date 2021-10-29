using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndOTP.Migrations
{
    public partial class tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hospitals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hospital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataconsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaConslta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospitals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpf = table.Column<int>(type: "int", nullable: false),
                    dateDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "consultas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    hospitalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultas", x => x.id);
                    table.ForeignKey(
                        name: "FK_consultas_hospitals_hospitalID",
                        column: x => x.hospitalID,
                        principalTable: "hospitals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consultas_usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_consultas_hospitalID",
                table: "consultas",
                column: "hospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_consultas_usuarioID",
                table: "consultas",
                column: "usuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consultas");

            migrationBuilder.DropTable(
                name: "hospitals");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
