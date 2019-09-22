using System.Collections.Generic;
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
    public class ContatoController : ControllerBase
    {
        private readonly IContatoApplication _contatoApplication;
        public ContatoController(IContatoApplication contatoApplication)
        {
            _contatoApplication = contatoApplication;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<Contato>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var contatos = await _contatoApplication.BuscarAsync();
            if (!contatos.Any())
                return NotFound();

            return Ok(contatos);
        }

        [HttpGet("{id}", Name = "GetByIdContato")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Contato),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            if (id.Equals(0))
                return BadRequest("Id deve ser informado");

            var result = await _contatoApplication.BuscarAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Contato), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] Contato entity)
        {
            await _contatoApplication.InserirAsync(entity);
            return Created("/", entity.IdContato);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Contato), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Put(int id, [FromBody] Contato entity)
        {

            if (id.Equals(0))
                return BadRequest("Id deve ser informado");

            entity.IdContato = id;

            await _contatoApplication.AtualizarAsync(entity);

            return NoContent();
        }
    }
}
