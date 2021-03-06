﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Domain.Interfaces.Base
{
    public interface IBaseApplication<TEntity> where TEntity : class
    {
        Task InserirAsync(TEntity entity);
        Task AtualizarAsync(TEntity entity);
        Task<IList<TEntity>> BuscarAsync();
        Task<TEntity> BuscarAsync(int pk);
        Task DeletarAsync(int pk);
    }
}