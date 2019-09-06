﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Base;
using Fiap.CloseRain.Domain.Interfaces.Repository;

namespace Fiap.CloseRain.Application.Applications
{
    public class UsuarioApplication : BaseApplication<Usuario, int>, IUsuarioApplication
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioApplication(IBaseRepository<Usuario, int> baseRepository, IUsuarioRepository usuarioRepository) : base(baseRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Autenticar(Usuario usuario)
        {
            return await _usuarioRepository.Autenticar(usuario);
        }
    }
}