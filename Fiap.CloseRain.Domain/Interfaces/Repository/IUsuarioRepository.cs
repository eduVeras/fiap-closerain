using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Base;

namespace Fiap.CloseRain.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, int>
    {
        bool Autenticar(Usuario usuario);
    }
}