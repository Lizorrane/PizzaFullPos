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
        public async Task <ActionResult<Pedido>> Add(Pedido pedido)
           {
            await pedidoService.Add(pedido);
            // 201
            return CreatedAtAction(
                nameof(GetById),
                new { id = pedido.Id, pedido});

        }

    }
}
