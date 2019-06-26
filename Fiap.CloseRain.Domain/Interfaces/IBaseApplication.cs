using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Domain.Interfaces
{
    public interface IBaseApplication<TEntity,in PK> where TEntity : class
    {
        Task InserirAsync(TEntity entity);
        Task AtualizarAsync(TEntity entity);
        Task<IList<TEntity>> BuscarAsync();
        Task<TEntity> BuscarAsync(PK pk);
        Task DeletarAsync(PK pk);
    }
}