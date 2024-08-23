using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedidos.Infra.Migrations
{
    public partial class PopularTabelaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserir produtos de exemplo
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "NomeProduto", "Valor" },
                values: new object[,]
                {
                { "Arroz", 25.00m },
                { "Feijão", 18.50m },
                { "Macarrão", 8.75m },
                { "Óleo de Soja", 12.90m },
                { "Açúcar", 5.60m },
                { "Leite", 4.20m },
                { "Café", 15.30m },
                { "Margarina", 7.45m },
                { "Molho de Tomate", 6.80m },
                { "Papel Higiênico", 9.10m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Produto");
        }
    }
}
