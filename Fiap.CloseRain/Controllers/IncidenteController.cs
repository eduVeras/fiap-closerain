﻿using System.Collections.Generic;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities;

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

        [HttpGet("{id}", Name = "GetByIdIncidente")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _incidenteApplication.BuscarAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Dictionary<string, string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] Incidente entity)
        {

            var isValid = entity.IsValid();

            if (!isValid.Valid)
                return BadRequest(isValid.Errors);

            await _incidenteApplication.InserirAsync(entity);
            return Created("/incidente/", entity.IdIncidente);

        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Dictionary<string, string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] Incidente entity)
        {

            var isValid = entity.IsValid();

            if (!isValid.Valid)
                return BadRequest(isValid.Errors);

            entity.IdIncidente = id;
            await _incidenteApplication.AtualizarAsync(entity);

            return NoContent();

        }
    }
}
