using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pedidos.Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string NomeProduto { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        [JsonIgnore]
        public virtual ICollection<ItensPedido>? ItensPedidos { get; set; }
    }
}
