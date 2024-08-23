namespace Pedidos.Dominio.Dtos.Responses
{
    public record ProdutoResponse
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}
