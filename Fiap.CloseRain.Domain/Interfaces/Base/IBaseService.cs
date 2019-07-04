using System.Threading.Tasks;

namespace Fiap.CloseRain.Domain.Interfaces.Base
{
    public interface IBaseService
    {
        Task Get();
        Task Post();
        Task Put();
        Task Delete();
    }
}