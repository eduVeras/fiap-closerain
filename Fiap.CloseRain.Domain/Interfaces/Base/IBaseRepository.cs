using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Domain.Interfaces.Base
{
    public interface IBaseRepository<TEntity, in TPk> where TEntity : class
    {
        Task InserirAsync(TEntity entity);
        Task AtualizarAsync(TEntity entity);
        Task<IList<TEntity>> BuscarAsync();
        Task<TEntity> BuscarAsync(TPk pk);
        Task DeletarAsync(TPk pk);
    }
}