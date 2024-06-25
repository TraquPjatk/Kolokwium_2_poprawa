using KolokwiumDF.DTOs;
using KolokwiumDF.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitsController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpPost]
        public async Task<IActionResult> AddVisit([FromBody] VisitDto visitDto)
        {
            try
            {
                var visitId = await _visitService.AddVisitAsync(visitDto.IdPatient, visitDto.IdDoctor, visitDto.Date);

                if (visitId == null)
                {
                    return BadRequest("Visit can not be scheduled.");
                }

                return Ok(visitId);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}