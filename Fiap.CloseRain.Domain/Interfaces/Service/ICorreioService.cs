using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities;

namespace Fiap.CloseRain.Domain.Interfaces.Service
{
    public interface ICorreioService
    {
        Task<Regiao> GetAddresByCepAsync(string cep);
    }
}