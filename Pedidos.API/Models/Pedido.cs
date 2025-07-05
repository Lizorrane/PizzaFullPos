using System.ComponentModel.DataAnnotations;

namespace PedidosAPI.Models
{
    public class Pedido
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [EmailAddress]
        public string Cliente { get; set; } = string.Empty;
        public int PizzaId { get; set; }
        public int Quantidade { get; set; }
        public enum StatusPedido
        {
            Recebido,
            EmPreparacao,
            Finalizado,
        }
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; } 
        public StatusPedido SituacaoId {get; set;} = StatusPedido.Recebido;
        public string Situacao => SituacaoId.ToString();
    }
}
