using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco.Migrations
{
    public partial class Primeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arrecadacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QtdParticipantes = table.Column<int>(nullable: false),
                    QtdAlimento = table.Column<float>(nullable: false),
                    MetaArrecadacao = table.Column<float>(nullable: false),
                    IdadePublicoAlvo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrecadacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Telefone = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValorDoacao = table.Column<float>(nullable: false),
                    MetaArrecadacao = table.Column<float>(nullable: false),
                    ValorArrecadacao = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rua = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
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
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeEmpresa = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeAtividade = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<DateTime>(nullable: false),
                    Categoria = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    EnderecoId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    QtdPrticipantes = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaFisicaId = table.Column<int>(nullable: true),
                    PessoaJuridicaId = table.Column<int>(nullable: true),
                    ContatoId = table.Column<int>(nullable: true),
                    OficinaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Contatos_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Eventos_OficinaId",
                        column: x => x.OficinaId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_PessoaFisica_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_PessoaJuridica_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PessoaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosEventos",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false),
                    EventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosEventos", x => new { x.UsuarioId, x.EventoId });
                    table.ForeignKey(
                        name: "FK_UsuariosEventos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosEventos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EnderecoId",
                table: "Eventos",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ContatoId",
                table: "Usuarios",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_OficinaId",
                table: "Usuarios",
                column: "OficinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PessoaFisicaId",
                table: "Usuarios",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PessoaJuridicaId",
                table: "Usuarios",
                column: "PessoaJuridicaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosEventos_EventoId",
                table: "UsuariosEventos",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arrecadacoes");

            migrationBuilder.DropTable(
                name: "Doacoes");

            migrationBuilder.DropTable(
                name: "UsuariosEventos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "PessoaJuridica");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
