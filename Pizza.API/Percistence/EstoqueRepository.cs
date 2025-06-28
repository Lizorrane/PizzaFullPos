using Pizza.API.Exceptions;
using Pizza.API.Models;

namespace Pizza.API.Percistence
{
    public class EstoqueRepository(PizzaDbContext dbContext)
    {
        public List<Estoque> GetAll()
        {
            return dbContext.Estoques.ToList();
        }

        public Estoque GetById(int id)
        {
            var estoque = dbContext.Estoques.FirstOrDefault(e => e.Id == id);

            if (estoque == null)
            {
                throw new NaoEncontradoException("Estoque não cadastrado.");
            }
            return estoque;
        }

        public Estoque Add(Estoque estoque)
        {
            var pizza = dbContext.Pizzas.FirstOrDefault(p => p.Id == estoque.PizzaId);

            if (pizza is null)
            {
                throw new ArgumentException("A pizza ainda não foi cadastrada");
            }

            var existeEstoque = dbContext.Estoques.FirstOrDefault(e => e.PizzaId == estoque.PizzaId);

            if (existeEstoque is not null)
            {
                throw new ArgumentException("Já existe estoque cadastrado para a pizza!");
            }

            estoque.Pizza = pizza;

            dbContext.Estoques.Add(estoque);    
            dbContext.SaveChanges();

            return estoque;
        }

        public Estoque GetByPizzaId(int pizzaId)
        {
            var estoque = dbContext.Estoques.FirstOrDefault(e => e.PizzaId == pizzaId);

            if (estoque is null)
            {
                throw new NaoEncontradoException("Pizza não encontrada");
            }
            return estoque;
        }

        public Estoque Update(int pizzaId, int quantidadeARemover)
        {
            var estoque = GetByPizzaId(pizzaId);

            // verificar se está pedindo mais pizzas do que temos em estoque
            if (quantidadeARemover > estoque.Quantidade)
            {
                throw new ArgumentException("A quantidade solicitada é superior ao estoque atual.");

            }
            estoque.Quantidade -= quantidadeARemover;
            estoque.AtualizadoEm = DateTime.UtcNow;

            dbContext.Update(estoque);
            dbContext.SaveChanges();

            return estoque;
        }
    }
}
