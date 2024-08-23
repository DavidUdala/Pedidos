namespace Pedidos.Dominio.Dtos.Requests
{
    public record ItemPedidoRequest
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
