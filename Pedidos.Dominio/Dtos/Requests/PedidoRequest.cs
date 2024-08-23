namespace Pedidos.Dominio.Dtos.Requests
{
    public record PedidoRequest
    {
        public string NomeCliente { get; set; } = string.Empty;
        public string EmailCliente { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Pago { get; set; }
        public List<ItemPedidoRequest>? ItensPedidos { get; set; }
    }
}
