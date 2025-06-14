using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet ("add")]
        public IActionResult Add([FromQuery] double a, [FromQuery] double b)
        {
            return Ok(new { resultado = a + b });
        }

        [HttpGet("subtract")]
        public IActionResult Subtract([FromQuery] double a, [FromQuery] double b)
        {
            return Ok (new { resultado = a - b });
        }

        [HttpGet("multiply")]
        public IActionResult Multiply([FromQuery] double a, [FromQuery] double b)
        {
            return Ok(new { resultado = a * b });
        }

        [HttpGet("divide")]
        public IActionResult Divide([FromQuery] double a, [FromQuery] double b)
        {
            if (b == 0)
                return BadRequest(new { error = "No se puede dividir por cero." });

            return Ok(new { resultado = a / b });
        }
    }
}





