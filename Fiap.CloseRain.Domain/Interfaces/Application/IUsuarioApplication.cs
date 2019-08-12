using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Base;

namespace Fiap.CloseRain.Domain.Interfaces.Application
{
    public interface IUsuarioApplication : IBaseApplication<Usuario, int>
    {
        Task<bool> Autenticar(Usuario usuario);
    }
}