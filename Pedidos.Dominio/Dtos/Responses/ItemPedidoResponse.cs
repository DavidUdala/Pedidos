namespace Pedidos.Dominio.Dtos.Responses
{
    public record ItemPedidoResponse
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
