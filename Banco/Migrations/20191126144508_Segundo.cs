using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco.Migrations
{
    public partial class Segundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_PessoaFisica_PessoaFisicaId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_PessoaJuridica_PessoaJuridicaId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoaJuridica",
                table: "PessoaJuridica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoaFisica",
                table: "PessoaFisica");

            migrationBuilder.RenameTable(
                name: "PessoaJuridica",
                newName: "PessoasJuridicas");

            migrationBuilder.RenameTable(
                name: "PessoaFisica",
                newName: "PessoasFisicas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoasJuridicas",
                table: "PessoasJuridicas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoasFisicas",
                table: "PessoasFisicas",
                column: "Id");

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
                name: "FK_Usuarios_PessoasFisicas_PessoaFisicaId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_PessoasJuridicas_PessoaJuridicaId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoasJuridicas",
                table: "PessoasJuridicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoasFisicas",
                table: "PessoasFisicas");

            migrationBuilder.RenameTable(
                name: "PessoasJuridicas",
                newName: "PessoaJuridica");

            migrationBuilder.RenameTable(
                name: "PessoasFisicas",
                newName: "PessoaFisica");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoaJuridica",
                table: "PessoaJuridica",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoaFisica",
                table: "PessoaFisica",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_PessoaFisica_PessoaFisicaId",
                table: "Usuarios",
                column: "PessoaFisicaId",
                principalTable: "PessoaFisica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_PessoaJuridica_PessoaJuridicaId",
                table: "Usuarios",
                column: "PessoaJuridicaId",
                principalTable: "PessoaJuridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
