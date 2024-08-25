using calcularDiasHabiles.Bussiness;
using calcularDiasHabiles.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace calcularDiasHabiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcularFestivosController : ControllerBase
    {
        private readonly IHolidayBussiness _HolidayBussiness;

        public CalcularFestivosController (IHolidayBussiness holidayBussiness)
        {
            _HolidayBussiness = holidayBussiness;
        }

        [HttpGet("CalcularFestivos")]
        public async Task<HolidaysEntities> CalcularFestivos()
        {
            HolidaysEntities kellyM = await _HolidayBussiness.CalcularApiFestivos();
            return kellyM;
        }
     }
}
