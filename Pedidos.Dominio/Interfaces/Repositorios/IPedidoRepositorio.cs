using Pedidos.Dominio.Entidades;

namespace Pedidos.Dominio.Interfaces.Repositorios
{
    public interface IPedidoRepositorio
    {
        Task<Pedido?> GetByIdAsync(int id);
        Task<List<Pedido>> GetAllAsync();
        Task AddAsync(Pedido pedido);
        Task UpdateAsync(Pedido pedido);
        Task DeleteAsync(int id);
    }
}
