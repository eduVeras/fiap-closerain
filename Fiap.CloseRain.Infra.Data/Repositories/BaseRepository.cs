using Fiap.CloseRain.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Fiap.CloseRain.Infra.Data.Repositories
{
    public class BaseRepository<T, TPk> : IBaseApplication<T, TPk> where T : class
    {
        protected DbContext DbContext { get; set; }
        protected readonly DbSet<T> _dbSet;

        public BaseRepository()
        {
            _dbSet = DbContext.Set<T>();
        }
        public async Task InserirAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task AtualizarAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }

        public async Task<IList<T>> BuscarAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> BuscarAsync(TPk pk)
        {
            return await _dbSet.FindAsync(pk);
        }

        public async Task DeletarAsync(TPk pk)
        {

            var data = await BuscarAsync(pk);
            if (data == null)
                return;

            _dbSet.Remove(data);
            await SaveAsync();
        }

        private async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
