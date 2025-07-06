using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Models;
using Pedidos.API.Services;

namespace Pedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController(PedidoService pedidoService)
        : ControllerBase
    {
        [HttpGet("{id}")]
        public Pedido GetById(Guid id)
        {
            return pedidoService.GetById(id);
        }


        [HttpGet]
        public List<Pedido> GetAll()
        {
            return pedidoService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Add(Pedido pedido)
        {
            try
            {
                await pedidoService.Add(pedido);
                return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERRO] {ex.GetType().Name}: {ex.Message}");
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
