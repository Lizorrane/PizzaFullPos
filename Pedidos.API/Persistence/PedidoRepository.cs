
using PedidosAPI.Models;
using PedidosAPI.Persistence;

namespace PedidosAPI.Persistence
{
    public class PedidoRepository(PedidoDbContext dbContext)
    {
        //Criar => Create
        public Pedido Add(Pedido pedido)
        {
            dbContext.Pedidos.Add(pedido);
            dbContext.SaveChanges();

            return pedido;
        }
        //GetById
        public Pedido? GetById(Guid id)
        {
            //dbContext.Pedidos.FirstOrDefault(p => p.Id == id);
            return dbContext.Pedidos.Find(id);
        }
        //GetAll
        public List<Pedido> GetAll()
        {
            return dbContext.Pedidos.ToList();
        }
    }
}