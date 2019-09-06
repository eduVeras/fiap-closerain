﻿using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Repository;

namespace Fiap.CloseRain.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario,int>, IUsuarioRepository
    {
        public Task<bool> Autenticar(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }
    }
}