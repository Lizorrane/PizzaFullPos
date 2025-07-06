using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pedidos.API.Exceptions;

namespace Pedidos.API.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception is NaoEncontradoException)
            {
                return Problem(statusCode: 404, title: "Recurso não encontrado",
                               detail: exception.Message);
            }

            if (exception is ArgumentException)
            {
                return Problem(statusCode: 400, title: "Erro de argumento inválido",
                               detail: exception.Message);
            }

            return Problem(statusCode: 500, title: "Erro interno inesperado",
                           detail: exception?.Message);
        }
    }
}
