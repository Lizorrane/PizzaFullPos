using Microsoft.AspNetCore.Mvc;
using Pizza.API.Percistence;


namespace Pizza.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaborController(PizzaRepository _pizzaRepository) : ControllerBase
    {
        [HttpPost]
        public ActionResult<Models.Pizza> Create(Models.Pizza pizza)
        {
            _pizzaRepository.Add(pizza);
            return CreatedAtAction(nameof(GetById), new { id = pizza.Id}, pizza);
        }

        [HttpGet]
        public List<Models.Pizza> GetAll()
        {
            return _pizzaRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Models.Pizza GetById(int id)
        {
            return _pizzaRepository.GetById(id);
        }
    }
}
