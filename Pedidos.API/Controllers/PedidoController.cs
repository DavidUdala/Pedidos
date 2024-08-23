using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Dominio.Dtos.Requests;
using Pedidos.Dominio.Dtos.Responses;
using Pedidos.Dominio.Entidades;
using Pedidos.Dominio.Interfaces.Repositorios;

namespace Pedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController(IPedidoRepositorio pedidoRepositorio, IMapper mapper) : ControllerBase
    {
        private readonly IPedidoRepositorio pedidoRepositorio = pedidoRepositorio;
        private readonly IMapper mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pedidos = await pedidoRepositorio.GetAllAsync();

            var result = mapper.Map<List<PedidoResponse>>(pedidos);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pedido = await pedidoRepositorio.GetByIdAsync(id);
            if (pedido == null)
                return NotFound();
            var result = mapper.Map<PedidoResponse>(pedido);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PedidoRequest pedidoRequest)
        {
            var pedido = mapper.Map<Pedido>(pedidoRequest);

            await pedidoRepositorio.AddAsync(pedido);

            var responseDto = mapper.Map<PedidoResponse>(pedido);
            return Ok(responseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pedido pedido)
        {
            if (id != pedido.Id)
                return BadRequest();

            await pedidoRepositorio.UpdateAsync(pedido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await pedidoRepositorio.DeleteAsync(id);
            return NoContent();
        }
    }
}
