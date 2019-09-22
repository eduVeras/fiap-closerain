using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplication _usuarioApplication;
        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        /// <summary>
        /// Serviço utilizado para autenticação do usuario no aplicativo.
        /// </summary>
        /// <param name="entity">Credencias do usuario que está tentando se logar.</param>
        /// <returns>Este serviço ira retornar o StatusCode 200 caso o usuario seja autentico, do contrario irá retornar 401. </returns>
        [HttpPost, Route("Autenticar")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Dictionary<string, string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Autenticar([FromBody] Usuario entity)
        {
            var isValid = entity.IsValid();

            if (!isValid.Valid)
                return BadRequest(isValid.Errors);

            var user = await _usuarioApplication.Autenticar(entity);

            if (user)
                return Ok();

            return Unauthorized();
        }

        /// <summary>
        /// Serviço utilizado para cadastrar novos usuarios que desejam utilizar o aplicativo.
        /// </summary>
        /// <param name="entity">Informações do usuario que está se cadastrando</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Usuario), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] Usuario entity)
        {
            var isValid = entity.IsValid();

            if (!isValid.Valid)
                return BadRequest(isValid.Errors);

            await _usuarioApplication.InserirAsync(entity);

            return Created("/", entity.IdUsuario);
        }

        [HttpGet,Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<Usuario>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            if (id.Equals(0))
                return BadRequest("Id deve ser informado");

            var result = await _usuarioApplication.BuscarAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario entity)
        {
            if (id.Equals(0))
                return BadRequest(new { Success = false, Mensagem = "Id deve ser preehnchido" });

            entity.IdUsuario = id;

            await _usuarioApplication.AtualizarAsync(entity);

            return NoContent();
        }



    }
}