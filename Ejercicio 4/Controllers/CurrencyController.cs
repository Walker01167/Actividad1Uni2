using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        // Tasa de cambio simulada desde USD
        private readonly Dictionary<string, double> ratesFromUSD = new Dictionary<string, double>
        {
            { "USD", 1.0 },
            { "EUR", 0.93 },
            { "DOP", 59.0 }
        };

        [HttpGet("convert")]
        public IActionResult Convert(double amount, string from, string to)
        {
            from = from.ToUpper();
            to = to.ToUpper();

            if (!ratesFromUSD.ContainsKey(from) || !ratesFromUSD.ContainsKey(to))
            {
                return BadRequest(new { error = "Moneda no soportada. Use USD, EUR o DOP." });
            }

            // Convertir monto a USD primero si es necesario
            double amountInUSD = amount;

            if (from != "USD")
                amountInUSD = amount / ratesFromUSD[from];

            // luego convertir desde USD a la moneda deseada
            double convertedAmount = amountInUSD * ratesFromUSD[to];

            return Ok(new
            {
                original = $"{amount} {from}",
                convertido = $"{convertedAmount:F2} {to}"
            });
        }
    }
}


