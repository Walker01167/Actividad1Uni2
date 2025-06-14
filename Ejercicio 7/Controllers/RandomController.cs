using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRandomNumber(int min = 1, int max = 100)
        {
            if (min >= max)
            {
                return BadRequest(new { error = "El valor mínimo debe ser menor que el valor máximo." });
            }

            var random = new Random();
            int number = random.Next(min, max + 1); // El +1 incluye el número máximo

            return Ok(new { numero = number });
        }
    }
}
