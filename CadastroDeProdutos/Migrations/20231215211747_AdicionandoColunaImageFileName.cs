using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeProdutos.Migrations
{
    public partial class AdicionandoColunaImageFileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageFileName",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageFileName",
                table: "Produtos");
        }
    }
}
