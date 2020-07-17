using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services.Time;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private ITimeService _service;
        private readonly IMapper _mapper;
        public TimesController(ITimeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetTimes([FromQuery] PaginateParameters paginateParameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var times = await _service.GetTimes(paginateParameters);

                var timesVideModel = _mapper.Map<List<TimeEntity>, List<TimeViewModel>>(times);
                var result = new TimesPaginateViewModel();
                var qtdPagina = await _service.Count();
                qtdPagina = qtdPagina / paginateParameters.TamanhoPagina + 1;

                result.Times = timesVideModel;
                result.TamanhoPagina = paginateParameters.TamanhoPagina;
                result.QtdPagina = qtdPagina;
                result.Pagina = paginateParameters.Pagina;

                return Ok(result);

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }  

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get(id));

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TimeEntity time)
        {
            var validation = time.Validar(_service);

            if (!ModelState.IsValid || !validation.IsValid)
            {
                return BadRequest(validation.Errors); 
            }

            try
            {

                var result = await _service.Post(time);
                if (result != null)
                {
                    return Ok();
                }
                else 
                { 
                    return BadRequest(); 
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] TimeEntity time)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                time.Id = id;
                var result = await _service.Put(time);
                if (result != null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            { 
                return Ok(await _service.Delete(id));
                //TODO fazer esquema de retornar notification de pq não excluiu
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
