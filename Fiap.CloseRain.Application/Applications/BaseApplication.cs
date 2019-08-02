using Fiap.CloseRain.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Application.Applications
{
    public class BaseApplication<T, TPk> : IBaseApplication<T, TPk> where T : class 
    {
        private readonly IBaseRepository<T, TPk> _baseRepository;
        public BaseApplication(IBaseRepository<T, TPk> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task InserirAsync(T entity)
        {
            await _baseRepository.InserirAsync(entity);
        }

        public async Task AtualizarAsync(T entity)
        {
            await _baseRepository.AtualizarAsync(entity);
        }

        public async Task<IList<T>> BuscarAsync()
        {
            return await _baseRepository.BuscarAsync();
        }

        public async Task<T> BuscarAsync(TPk pk)
        {
            return await _baseRepository.BuscarAsync(pk);
        }

        public async Task DeletarAsync(TPk pk)
        {
            await _baseRepository.DeletarAsync(pk);
        }
    }
}
