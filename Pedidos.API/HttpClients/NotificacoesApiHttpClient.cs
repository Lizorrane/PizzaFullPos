namespace PedidosAPI.HttpClients
{
    public class NotificacoesApiHttpClient
    {
       public sealed class Client(HttpClient httpClient)
       {
        public async Task CriarNotificacoesAsync(Guid pedidoId, string destinatario, string mensagem)
        {
            var res = await httpClient
            .PostAsJsonAsync("/notificacao", new {
                pedidoId,
                destinatario,
                mensagem
            });
            res.EnsureSuccessStatusCode();
        }
       }
    }
}

