using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.CloseRain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenteController : ControllerBase
    {
        private readonly IIncidenteApplication _incidenteApplication;
        public IncidenteController(IIncidenteApplication incidenteApplication)
        {
            _incidenteApplication = incidenteApplication;
        }
        
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            var incidentes = await _incidenteApplication.BuscarAsync();

            if (!incidentes.Any())
                return NotFound();

            return Ok(incidentes);
        }

        // GET: api/Incidente/5
        [HttpGet("{id}", Name = "GetByIdIncidente")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Incidente
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Incidente/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
