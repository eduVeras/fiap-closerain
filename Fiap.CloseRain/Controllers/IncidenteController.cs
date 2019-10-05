using System.Collections.Generic;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Models;

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

        /// <summary>
        /// Busca todos os incidentes cadastrados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<Incidente>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var incidentes = await _incidenteApplication.BuscarAsync();

            if (!incidentes.Any())
                return NotFound();

            return Ok(incidentes);
        }

        /// <summary>
        /// Busca um incidente especifico pela sua referencia.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetByIdIncidente")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Regiao), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _incidenteApplication.BuscarAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// Realiza a busca de todos incidentes a partir de um usuario.
        /// </summary>
        /// <param name="idUsuario">Id de referencia do usuario.</param>
        /// <returns></returns>
        [HttpGet("{idUsuario}", Name = "GetByIdUsuario")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Regiao), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByUsuario(int idUsuario)
        {
            var data = await _incidenteApplication.BuscarPorUsuarioAsync(idUsuario);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// Busca os ultimos incidentes cadastrados.
        /// </summary>
        /// <param name="qtdRegistro"></param>
        /// <returns></returns>
        [HttpGet("{qtdRegistro}", Name = "GetLatest")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Regiao), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLatest(int qtdRegistro)
        {
            var data = await _incidenteApplication.BuscarUltimosAsync(qtdRegistro);
            if (data == null)
                return NotFound();

            return Ok(data);
        }


        /// <summary>
        /// Serviço utilizado para o cadastro de um novo incidente, será informado o local do incidente, e o usuario que está notificando.
        /// </summary>
        /// <param name="vm">Conteudo do incidente</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Dictionary<string, string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] IncidenteViewModel vm)
        {
            var entity = vm.Parse();

            var isValid = entity.IsValid();

            if (!isValid.Valid)
                return BadRequest(isValid.Errors);

            await _incidenteApplication.InserirAsync(entity);
            return Created("GetByIdIncidente", entity.IdIncidente);

        }

        /// <summary>
        /// Serviço responsavel pela atualização dos dados de um incidente.
        /// </summary>
        /// <param name="id">Referencia do incididente</param>
        /// <param name="vm">Novo conteudo</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Dictionary<string, string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] IncidenteViewModel vm)
        {

            var entity = vm.Parse();

            var isValid = entity.IsValid();

            if (!isValid.Valid)
                return BadRequest(isValid.Errors);

            entity.IdIncidente = id;
            await _incidenteApplication.AtualizarAsync(entity);

            return NoContent();
        }
    }
}
