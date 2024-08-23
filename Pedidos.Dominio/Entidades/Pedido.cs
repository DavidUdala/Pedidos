using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pedidos.Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string NomeCliente { get; set; } = string.Empty;
        [Column(TypeName = "varchar(60)")]
        public string EmailCliente { get; set; } = string.Empty;
        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Pago { get; set; }
        [JsonIgnore]
        public virtual ICollection<ItensPedido>? ItensPedidos { get; set; }
    }
}
