using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio_9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeController : ControllerBase
    {
        [HttpGet("calculate")]
        public IActionResult CalculateAge([FromQuery] DateTime birthDate)
        {
            DateTime today = DateTime.Today;

            if (birthDate > today)
            {
                return BadRequest(new { error = "La fecha de nacimiento no puede ser en el futuro." });
            }

            int age = today.Year - birthDate.Year;

            // Ajuste si aún no ha cumplido años este año
            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }

            return Ok(new
            {
                fechaNacimiento = birthDate.ToString("yyyy-MM-dd"),
                edad = age
            });
        }
    }
}
