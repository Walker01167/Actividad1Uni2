using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Ejercicio_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        [HttpGet("generate")]
        public IActionResult Generate(int length = 12, bool includeSymbols = true)
        {
            if (length < 6 || length > 100)
            {
                return BadRequest(new { error = " La longitud debe estar entre 6 y 100 caracteres." });
            }

            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string symbols = "!@#$%^&*()-_=+[]{}<>?";

            string allowedChars = letters + numbers;
            if (includeSymbols)
            {
                allowedChars += symbols;
            }

            var random = new Random();
            var password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                char c = allowedChars[random.Next(allowedChars.Length)];
                password.Append(c);
            }

            return Ok(new { password = password.ToString() });
        }


    }
}
