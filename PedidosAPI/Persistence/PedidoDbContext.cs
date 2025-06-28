using Microsoft.EntityFrameworkCore;
using PedidosAPI.Models;

namespace PedidosAPI.Persistence
{
    public class PedidoDbContext(DbContextOptions<PedidoDbContext> options) : DbContext(options)
    {
       public DbSet<Pedido> Pedidos { get; set; } = null!;
    }
}
  