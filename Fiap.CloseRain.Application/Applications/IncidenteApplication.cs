using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Base;

namespace Fiap.CloseRain.Application.Applications
{
    public class IncidenteApplication : BaseApplication<Incidente,int>, IIncidenteApplication
    {
        public IncidenteApplication(IBaseRepository<Incidente, int> baseRepository) : base(baseRepository)
        {
        }
    }
}
