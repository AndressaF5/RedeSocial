using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco.Migrations
{
    public partial class Quarto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Eventos_OficinaId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_PessoaFisicaId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_PessoaJuridicaId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NomeSocial",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NomeEmpresa",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MetaArrecadacao",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "PublicoAlvo",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "QtdAlimento",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "QtdParticipantes",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Doacao_MetaArrecadacao",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "ValorArrecadado",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "ValorDoacao",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "NomeOficina",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Oficina_QtdParticipantes",
                table: "Eventos");

            migrationBuilder.CreateTable(
                name: "Arrecadacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QtdParticipantes = table.Column<int>(nullable: false),
                    QtdAlimento = table.Column<float>(nullable: false),
                    MetaArrecadacao = table.Column<float>(nullable: false),
                    PublicoAlvo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrecadacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValorDoacao = table.Column<float>(nullable: false),
                    MetaArrecadacao = table.Column<float>(nullable: false),
                    ValorArrecadado = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oficinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeOficina = table.Column<string>(nullable: true),
                    QtdParticipantes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoasFisicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    NomeSocial = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    Genero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasFisicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoasJuridicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeEmpresa = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    EnderecoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasJuridicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoasJuridicas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoasJuridicas_EnderecoId",
                table: "PessoasJuridicas",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Oficinas_OficinaId",
                table: "Usuarios",
                column: "OficinaId",
                principalTable: "Oficinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_PessoasFisicas_PessoaFisicaId",
                table: "Usuarios",
                column: "PessoaFisicaId",
                principalTable: "PessoasFisicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_PessoasJuridicas_PessoaJuridicaId",
                table: "Usuarios",
                column: "PessoaJuridicaId",
                principalTable: "PessoasJuridicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Oficinas_OficinaId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_PessoasFisicas_PessoaFisicaId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_PessoasJuridicas_PessoaJuridicaId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Arrecadacoes");

            migrationBuilder.DropTable(
                name: "Doacoes");

            migrationBuilder.DropTable(
                name: "Oficinas");

            migrationBuilder.DropTable(
                name: "PessoasFisicas");

            migrationBuilder.DropTable(
                name: "PessoasJuridicas");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeSocial",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeEmpresa",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "MetaArrecadacao",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublicoAlvo",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "QtdAlimento",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QtdParticipantes",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Doacao_MetaArrecadacao",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ValorArrecadado",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ValorDoacao",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Eventos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeOficina",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Oficina_QtdParticipantes",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Eventos_OficinaId",
                table: "Usuarios",
                column: "OficinaId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_PessoaFisicaId",
                table: "Usuarios",
                column: "PessoaFisicaId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_PessoaJuridicaId",
                table: "Usuarios",
                column: "PessoaJuridicaId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
