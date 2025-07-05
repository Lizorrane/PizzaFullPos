using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Models;
using PedidosAPI.Services;

namespace PedidosAPI.Controllers
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
        public async Task<Pedido> Add(Pedido pedido)
        {
            return await pedidoService.Add(pedido);
        }

    }
}
