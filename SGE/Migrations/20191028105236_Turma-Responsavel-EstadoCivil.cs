using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGE.Migrations
{
    public partial class TurmaResponsavelEstadoCivil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Periodo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsavel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    CPF = table.Column<string>(maxLength: 15, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Celular = table.Column<string>(maxLength: 15, nullable: true),
                    TelefoneFixo = table.Column<string>(maxLength: 15, nullable: true),
                    DateNascimento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(maxLength: 15, nullable: true),
                    Logradouro = table.Column<string>(maxLength: 50, nullable: true),
                    Complemento = table.Column<string>(maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 50, nullable: true),
                    UF = table.Column<string>(maxLength: 2, nullable: true),
                    CEP = table.Column<string>(maxLength: 15, nullable: true),
                    Numero = table.Column<string>(maxLength: 10, nullable: true),
                    ResposavelLegal = table.Column<string>(maxLength: 50, nullable: true),
                    ResposavelFinanceiro = table.Column<string>(maxLength: 50, nullable: true),
                    TipoUsuarioId = table.Column<int>(nullable: false),
                    EstadoCivilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsavel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsavel_EstadoCivil_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadoCivil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responsavel_TipoUsuario_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_EstadoCivilId",
                table: "Responsavel",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_TipoUsuarioId",
                table: "Responsavel",
                column: "TipoUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responsavel");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "EstadoCivil");
        }
    }
}
