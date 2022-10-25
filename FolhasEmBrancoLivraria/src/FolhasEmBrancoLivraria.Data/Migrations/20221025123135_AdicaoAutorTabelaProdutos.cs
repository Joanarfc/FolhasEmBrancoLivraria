using Microsoft.EntityFrameworkCore.Migrations;

namespace FolhasEmBrancoLivraria.Data.Migrations
{
    public partial class AdicaoAutorTabelaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Produtos",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Produtos");
        }
    }
}
