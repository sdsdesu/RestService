using Microsoft.AspNetCore.Mvc;
using RestService.Services;

namespace RestService.Controllers
{
    [Route("sterrebeelden"), ApiController]
    public class SterrebeeldControler(IDatumLezerService service) : ControllerBase
    {
        [HttpGet("{dag}-{maand}")]
        public async Task<ActionResult> FindById(int dag, int maand)
        {
            if (dag < 1 || dag > 31 || maand < 1 || maand > 12)
            {
                return BadRequest("Ongeldige datum: Dag moet tussen 1 en 31 zijn, maand tussen 1 en 12.");
            }

            string sterrebeeld = await service.sterrebeeldNaam(dag, maand);
            if (string.IsNullOrEmpty(sterrebeeld))
            {
                return NotFound();
            }

            return Ok(sterrebeeld);
        }
    }
}
