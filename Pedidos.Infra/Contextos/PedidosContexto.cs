using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Entidades;

namespace Pedidos.Infra.Contextos
{
    public class PedidosContexto : DbContext
    {
        public PedidosContexto(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItensPedido> ItensPedido { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItensPedido>()
                .HasOne(ip => ip.Pedido)
                .WithMany(p => p.ItensPedidos)
                .HasForeignKey(t => t.IdPedido);

            modelBuilder.Entity<ItensPedido>()
                .HasOne(ip => ip.Produto)
                .WithMany(p => p.ItensPedidos)
                .HasForeignKey(t => t.IdProduto);
        }
    }
}
