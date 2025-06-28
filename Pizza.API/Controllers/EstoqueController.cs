using Microsoft.AspNetCore.Mvc;
using Pizza.API.Models;
using Pizza.API.Percistence;

namespace Pizza.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController(EstoqueRepository estoqueRepository) : ControllerBase
    {
        [HttpGet]
        public List<Estoque> GetAll()
        {
            return estoqueRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Estoque GetById(int id)
        {
            return estoqueRepository.GetById(id);
        }

        [HttpPost]
        public ActionResult<Estoque> Create(Estoque estoque)
        {
            estoqueRepository.Add(estoque);

            return CreatedAtAction(
                nameof(GetById),
                new { id = estoque.Id },
                estoque);
        }

        [HttpGet("pizza/{pizzaId}")]
        public Estoque GetByPizzaId(int pizzaId)
        {
            return estoqueRepository.GetByPizzaId(pizzaId);
        }

        [HttpPut("pizza/{pizzaId}/{quantidade}")]
        public Estoque Updade(int pizzaId, int quantidade)
        {
            return estoqueRepository.Update(pizzaId, quantidade);
        }
    }
}
