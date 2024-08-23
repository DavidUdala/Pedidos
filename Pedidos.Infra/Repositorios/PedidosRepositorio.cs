using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Entidades;
using Pedidos.Dominio.Interfaces.Repositorios;
using Pedidos.Infra.Contextos;

namespace Pedidos.Infra.Repositorios
{
    public class PedidosRepositorio : IPedidoRepositorio
    {
        private readonly PedidosContexto contexto;

        public PedidosRepositorio(PedidosContexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await contexto.Pedido
                .Include(p => p.ItensPedidos!)
                .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Pedido>> GetAllAsync()
        {
            return await contexto.Pedido
                .Include(p => p.ItensPedidos!)
                .ThenInclude(i => i.Produto)
                .ToListAsync();
        }

        public async Task AddAsync(Pedido pedido)
        {
            contexto.Pedido.Add(pedido);
            await contexto.SaveChangesAsync();
            await contexto.Pedido
            .Include(p => p.ItensPedidos!)
            .ThenInclude(ip => ip.Produto)
            .FirstOrDefaultAsync(p => p.Id == pedido.Id);
            await contexto.SaveChangesAsync();

        }
        public async Task UpdateAsync(Pedido pedido)
        {
            contexto.Entry(pedido).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pedido = await contexto.Pedido.FindAsync(id);
            if (pedido != null)
            {
                contexto.Pedido.Remove(pedido);
                await contexto.SaveChangesAsync();
            }
        }
    }
}
