using Pedidos.API.Exceptions;
using PedidosAPI.HttpClients;
using PedidosAPI.Models;
using PedidosAPI.Persistence;

namespace Pedidos.API.Services
{
    public class PedidoService(PedidoRepository repository, PizzaApiHttpClient.Client pizzaApi, NotificacoesApiHttpClient.Client notificacoesApi)
    {
        //Adicionar
        public async Task<Pedido> Add(Pedido pedido)
        {
            //1. Verificar se a pizza existe e se tem estoque
            var estoque = await pizzaApi.GetEstoque(pedido.PizzaId);
            if (estoque == null || estoque.Quantidade < pedido.Quantidade)
            {
                throw new Exception($"Estoque insuficiente");
            }
            //2. Atualiza o estoque
            await pizzaApi.UpdateEstoque(pedido.PizzaId, pedido.Quantidade);
            //3. Salvar o pedido
            repository.Add(pedido);
            
            //4. Notifica o cliente

            await notificacoesApi.CriarNotificacoesAsync(
                 pedido.Id,
                 pedido.Cliente, 
                 $"Seu pedido {pedido.Id} foi confirmado!");
            return pedido;
        }
        //ObterPorId
        public Pedido GetById(Guid id)
        {
            var pedido = repository.GetById(id);
            if (pedido == null)
            {
                throw new NaoEncontradoException("Pedido não encontrado.");
            }
            return pedido;
        }
        //Obter Todos
        public List<Pedido> GetAll()
        {
            return repository.GetAll();
        }
    }
}