using Fiap.CloseRain.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Infra.Data.Repositories
{
    public class BaseRepository<T, TPk> : IBaseApplication<T, TPk> where T : class
    {
        public async Task InserirAsync(T entity)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task AtualizarAsync(T entity)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<IList<T>> BuscarAsync()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<T> BuscarAsync(TPk pk)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task DeletarAsync(TPk pk)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
