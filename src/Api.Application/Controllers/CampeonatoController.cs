using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services.Campeonato;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : Controller
    {
        private ICampeonatoService _service;
        private readonly IMapper _mapper;

        public CampeonatoController(ICampeonatoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Campeonato()
        {
            try
            {
               var campeonato = await _service.GerarCampeonato();

                var partidas = campeonato.Partidas;
                var partidasVideModel = _mapper.Map<List<PartidaEntity>, List<PartidaViewModel>>(partidas);

                var result = new CampeonatoViewModel();
                result.Partidas = partidasVideModel;
                result.campeao = campeonato.Campeao.Nome;
                result.vice = campeonato.Vice.Nome;
                result.terceiro = campeonato.Terceiro.Nome;

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
