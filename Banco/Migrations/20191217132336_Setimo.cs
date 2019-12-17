using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco.Migrations
{
    public partial class Setimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amizade_Usuarios_UsuarioIdA",
                table: "Amizade");

            migrationBuilder.DropForeignKey(
                name: "FK_Amizade_Usuarios_UsuarioIdB",
                table: "Amizade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amizade",
                table: "Amizade");

            migrationBuilder.RenameTable(
                name: "Amizade",
                newName: "Amizades");

            migrationBuilder.RenameIndex(
                name: "IX_Amizade_UsuarioIdB",
                table: "Amizades",
                newName: "IX_Amizades_UsuarioIdB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amizades",
                table: "Amizades",
                columns: new[] { "UsuarioIdA", "UsuarioIdB" });

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_Usuarios_UsuarioIdA",
                table: "Amizades",
                column: "UsuarioIdA",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_Usuarios_UsuarioIdB",
                table: "Amizades",
                column: "UsuarioIdB",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_UsuarioIdA",
                table: "Amizades");

            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_UsuarioIdB",
                table: "Amizades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amizades",
                table: "Amizades");

            migrationBuilder.RenameTable(
                name: "Amizades",
                newName: "Amizade");

            migrationBuilder.RenameIndex(
                name: "IX_Amizades_UsuarioIdB",
                table: "Amizade",
                newName: "IX_Amizade_UsuarioIdB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amizade",
                table: "Amizade",
                columns: new[] { "UsuarioIdA", "UsuarioIdB" });

            migrationBuilder.AddForeignKey(
                name: "FK_Amizade_Usuarios_UsuarioIdA",
                table: "Amizade",
                column: "UsuarioIdA",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Amizade_Usuarios_UsuarioIdB",
                table: "Amizade",
                column: "UsuarioIdB",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
