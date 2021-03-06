﻿using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Application.Applications
{
    public class UsuarioApplication : BaseApplication<Usuario>, IUsuarioApplication
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioApplication(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Autenticar(Usuario usuario)
        {
            return await _usuarioRepository.Autenticar(usuario);
        }

        public override async Task InserirAsync(Usuario entity)
        {
            await base.InserirAsync(entity);
        }
    }
}
