using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        [HttpGet("convert")]
        public IActionResult Convert(string from, string? to, double value)
        {
            from = from.ToLower();
            to = to?.ToLower();

            double result = 0;
            string conversion = "";

            if (from == "km" && to == "miles")
            {
                result = value * 0.621371;
                conversion = $"{value} km = {result:F2} miles";
            }
            else if (from == "miles" && to == "km")
            {
                result = value / 0.621371;
                conversion = $"{value} miles = {result:F2} km";
            }
            else if (from == "kg" && (string.IsNullOrEmpty(to) || to == "1b"))
            {
                result = value * 2.20462;
                conversion = $"{value} kg = {result:F2} 1b";
            }
            else if (from == "1b" && to == "kg")
            {
                result = value / 2.20462;
                conversion = $"{value} 1b =  {result:F2} kg";
            }
            else
            {
                return BadRequest(new { error = "Conversion no soportada." });
            }

            return Ok(new { resultado = conversion });
        }
    }
}


