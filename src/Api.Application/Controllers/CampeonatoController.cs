using Domain.Interfaces.Services.Campeonato;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : Controller
    {
        private ICampeonatoService _service;

        
        public CampeonatoController(ICampeonatoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Campeonato()
        {
            try
            {
               return Ok(await _service.GerarCampeonato());

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
