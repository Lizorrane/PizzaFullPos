using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pizza.API.Exceptions;

namespace Pizza.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()!.Error;

            if (exception is NaoEncontradoException)
            {
                // return NotFound(exception.Message);
                return Problem(statusCode: 404, title: "Ocorreu um problema",
                               detail: exception.Message);
            }
            return Problem(title: "Ocorreu um problema não esperado");
        }
    }
}
