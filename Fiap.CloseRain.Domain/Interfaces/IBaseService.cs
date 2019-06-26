using System.Threading.Tasks;

namespace Fiap.CloseRain.Domain.Interfaces
{
    public interface IBaseService
    {
        Task Get();
        Task Post();
        Task Put();
        Task Delete();
    }
}