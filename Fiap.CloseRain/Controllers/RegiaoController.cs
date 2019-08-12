using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegiaoController : ControllerBase
    {
        private readonly IRegiaoApplication _regiaoApplication;
        public RegiaoController(IRegiaoApplication regiaoApplication)
        {
            _regiaoApplication = regiaoApplication;
        }

        // GET: api/Regiao
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var regioes = await _regiaoApplication.BuscarAsync();

            if (!regioes.Any())
                return NotFound();

            return Ok(regioes);
        }

        // GET: api/Regiao/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Regiao
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Regiao entity)
        {
            await _regiaoApplication.InserirAsync(entity);

            return Created("path", entity.Cep);

        }

        // PUT: api/Regiao/5
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
