using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Remotion.Linq.Utilities;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var regioes = await _regiaoApplication.BuscarAsync();

            if (!regioes.Any())
                return NotFound();

            return Ok(regioes);
        }

        // GET: api/Regiao/5
        [HttpGet("{id}", Name = "GetByIdRegiao")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Regiao), (int)HttpStatusCode.OK)]
        [ProducesResponseType( (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            if (id.Equals(0))
                return BadRequest("Id deve ser informado");

            var result  = await _regiaoApplication.BuscarAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] Regiao entity)
        {
            var isValid = entity.IsValid();

            if (!isValid.Valid)
                return BadRequest(isValid.Errors);

            await _regiaoApplication.InserirAsync(entity);

            return Created("/", entity.IdRegiao);

        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody] Regiao regiao)
        {
            if (id.Equals(0))
                return BadRequest(new {Success = false, Mensagem = "Id deve ser preehnchido"});

            regiao.IdRegiao = id;

            await _regiaoApplication.AtualizarAsync(regiao);

            return NoContent();
        }
    }
}
