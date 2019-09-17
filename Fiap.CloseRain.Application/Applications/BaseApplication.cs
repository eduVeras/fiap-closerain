using Fiap.CloseRain.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Application.Applications
{
    public class BaseApplication<T> : IBaseApplication<T> where T : class 
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseApplication(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task InserirAsync(T entity)
        {
            await _baseRepository.InserirAsync(entity);
        }

        public virtual async Task AtualizarAsync(T entity)
        {
            await _baseRepository.AtualizarAsync(entity);
        }

        public virtual async Task<IList<T>> BuscarAsync()
        {
            return await _baseRepository.BuscarAsync();
        }

        public virtual async Task<T> BuscarAsync(int pk)
        {
            return await _baseRepository.BuscarAsync(pk);
        }

        public virtual async Task DeletarAsync(int pk)
        {
            await _baseRepository.DeletarAsync(pk);
        }
    }
}
