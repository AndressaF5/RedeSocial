using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco.Migrations
{
    public partial class Sexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContatoId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ContatoId",
                table: "Eventos",
                column: "ContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Contatos_ContatoId",
                table: "Eventos",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Contatos_ContatoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_ContatoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "ContatoId",
                table: "Eventos");
        }
    }
}
