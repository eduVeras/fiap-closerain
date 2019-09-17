using Fiap.CloseRain.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fiap.CloseRain.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;


namespace Fiap.CloseRain.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseApplication<T> where T : class
    {
        private readonly CloseRainContext _dbContext; 
        protected readonly DbSet<T> DbSet;

        public BaseRepository(CloseRainContext context)
        {
            _dbContext = context;
            DbSet = _dbContext.Set<T>();
        }

        public async Task InserirAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task AtualizarAsync(T entity)
        {
            DbSet.Update(entity);
            await SaveAsync();
        }

        public async Task<IList<T>> BuscarAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> BuscarAsync(int pk)
        {
            return await DbSet.FindAsync(pk);
        }

        public async Task DeletarAsync(int pk)
        {

            var data = await BuscarAsync(pk);
            if (data == null)
                return;

            DbSet.Remove(data);
            await SaveAsync();
        }

        private async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
