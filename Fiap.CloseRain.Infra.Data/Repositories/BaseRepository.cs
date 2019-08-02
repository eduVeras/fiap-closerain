using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Interfaces.Base;

namespace Fiap.CloseRain.Infra.Data.Repositories
{
    public class BaseRepository<T, TPk> : IBaseApplication<T, TPk> where T : class
    {
        public async Task InserirAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task AtualizarAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<T>> BuscarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> BuscarAsync(TPk pk)
        {
            throw new NotImplementedException();
        }

        public async Task DeletarAsync(TPk pk)
        {
            throw new NotImplementedException();
        }
    }
}
