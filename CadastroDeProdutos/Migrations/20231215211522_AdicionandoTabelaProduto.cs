using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeProdutos.Migrations
{
    public partial class AdicionandoTabelaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preço = table.Column<double>(type: "float", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    imageFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataInsercao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
