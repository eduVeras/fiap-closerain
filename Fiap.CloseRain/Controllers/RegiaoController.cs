using System;
using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Fiap.CloseRain.Models;

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

        /// <summary>
        /// Realiza uma busca de todas as regioes cadastradas.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK,Type = typeof(List<Regiao>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                var regioes = await _regiaoApplication.BuscarAsync();

                if (!regioes.Any())
                    return NotFound();

                return Ok(regioes);
            }
            catch (Exception e)
            {
                return BadRequest(new ResultError(e));
            }
        }

        /// <summary>
        /// Busca uma regiao especifica por sua chave de referencia.
        /// </summary>
        /// <param name="id">Chave de referencia da Regiao (IdRegiao)</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetByIdRegiao")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Regiao), (int)HttpStatusCode.OK)]
        [ProducesResponseType( (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                if (id.Equals(0))
                    throw new Exception("Id deve ser informado");

                var result = await _regiaoApplication.BuscarAsync(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new ResultError(e));
            }
            
        }

        /// <summary>
        /// Realiza o cadastro de uma nova regiao.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] Regiao entity)
        {
            try
            {
                var isValid = entity.IsValid();

                if (!isValid.Valid)
                    return BadRequest(isValid.Errors);

                await _regiaoApplication.InserirAsync(entity);

                return Created("/", entity.IdRegiao);
            }
            catch (Exception e)
            {
                return BadRequest(new ResultError(e));
            }
        }

        /// <summary>
        /// Atualiza os dados de um regiao com base em sua chave de referencia.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="regiao"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody] Regiao regiao)
        {
            try
            {
                if (id.Equals(0))
                    throw new Exception("Id deve ser preenchido.");

                regiao.IdRegiao = id;

                await _regiaoApplication.AtualizarAsync(regiao);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new ResultError(e));
            }
            
        }
    }
}
