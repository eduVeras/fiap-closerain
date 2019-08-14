using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Get()
        {
            var contatos = await _contatoApplication.BuscarAsync();
            if (!contatos.Any())
                return NotFound();

            return Ok(contatos);
        }

        // GET: api/Contato/5
        [HttpGet("{id}", Name = "GetByIdContato")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contato
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Contato/5
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
