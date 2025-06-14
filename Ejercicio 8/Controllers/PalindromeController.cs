using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalindromeController : ControllerBase
    {
        [HttpGet("check")]
        public IActionResult CheckPalindrome([FromQuery] string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return BadRequest(new { error = "El texto no puede estar vacío." });
            }

            string cleanText = text.Replace(" ", "").ToLower();
            string reversed = new string(cleanText.Reverse().ToArray());

            bool esPalindromo = cleanText == reversed;

            return Ok(new
            {
                texto = text,
                esPalindromo
            });
        }
    }
}
