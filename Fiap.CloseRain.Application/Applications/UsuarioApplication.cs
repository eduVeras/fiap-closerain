using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Application.Applications
{
    public class UsuarioApplication : BaseApplication<Usuario>, IUsuarioApplication
    {
        private readonly ICorreioService _correioService;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioApplication(IUsuarioRepository usuarioRepository, ICorreioService correioService) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _correioService = correioService;
        }

        public async Task<bool> Autenticar(Usuario usuario)
        {
            return await _usuarioRepository.Autenticar(usuario);
        }

        public override async Task InserirAsync(Usuario entity)
        {

            if (string.IsNullOrWhiteSpace(entity.Regiao.Cep))
            {
                entity.Regiao = await _correioService.GetAddresByCepAsync(entity.Regiao.Cep);
            }

            await base.InserirAsync(entity);
        }
    }
}
