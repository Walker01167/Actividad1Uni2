using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelcomeControllers : ControllerBase
    {
        [HttpGet]
        public IActionResult Get ([FromQuery] string name)
        {
            var mensaje = new { mensaje = $"¡Bienvenido señor, {name}!" };
            return Ok(mensaje);
        }
    }
}
