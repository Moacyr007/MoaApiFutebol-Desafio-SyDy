using Domain.Entities;
using Domain.Interfaces.Services.Time;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private ITimeService _service;
        public TimesController(ITimeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                return Ok(await _service.GetAll());

            }
            catch (ArgumentException e)
            {
                return StatusCode ((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // api/times/{id}
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
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
        public async Task<ActionResult> Put([FromBody] TimeEntity time)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
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
